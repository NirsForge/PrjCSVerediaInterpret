﻿namespace Project
{
    internal class CodeFile
    {
        #region Initialise
        public CodeFile(string paf)
        {
            var file = new Files(paf);
            file.Read(out List<string> code);
            Code = code;

            for (int i = 0; i < Code.Count; i++)
            {
                if (Code[i].Length >= 2)
                    if (Code[i].Substring(0,2) == "//") Code.RemoveAt(i);

                if (Code[i].Length == 0) Code.RemoveAt(i);
            }

            Split();

            if (Missing()) Lib.End("Error: Missing argument");

            Token();
        }
        #endregion //Initialise

        #region Properties
        private List<StringToken> strTokens = new List<StringToken>();
        private List<IntToken> intTokens = new List<IntToken>();
        private List<DoubleToken> douTokens = new List<DoubleToken>();
        private List<BoolToken> boolTokens = new List<BoolToken>();
        private List<FunctionToken> funTokens = new List<FunctionToken>();
        private List<ClassToken> classTokens = new List<ClassToken>();
        private List<ConsoleToken> conToken = new List<ConsoleToken>();

        public List<Lines> ArgCode { get; private set; }
        public List<string> Code { get; private set; }
        #endregion //Properties

        private bool Missing()
        {
            List<int> clamp = new List<int>() { 0, 0, 0 }; //{ "{}", "[]", "()" }

            foreach (var item in ArgCode)
            {
                for (int i = 0; i < item.Line.Length; i++)
                {
                    if (item.Line[i] == "{")
                        clamp[0]++;
                    else if (item.Line[i] == "}")
                        clamp[0]--;
                    else if (item.Line[i] == "[")
                        clamp[1]++;
                    else if (item.Line[i] == "]")
                        clamp[1]--;
                    else if (item.Line[i] == "(")
                        clamp[2]++;
                    else if (item.Line[i] == ")")
                        clamp[2]--;
                }
            }

            if (clamp[0] == 0 && clamp[1] == 0 && clamp[2] == 0) return true;
            
            return false;
        }
        private void Split()
        {
            foreach (var line in Code)
            {
                ArgCode.Add(new Lines(line.Split(" ")));
            }

            foreach (var item in ArgCode)
            {
                for (int i = 0; i < item.Line.Length; i++)
                {
                    if (item.Line[i].Substring(0, item.Line[i].Length - 1) == ";")
                    {
                        item.Line[i] = item.Line[i].ToString().Substring(0, item.Line[i].Length - 1);
                        item.Line[i + 1] = ";";
                    }
                    else if (item.Line[i].Substring(0, item.Line[i].Length - 1) == ",")
                    {
                        item.Line[i] = item.Line[i].ToString().Substring(0, item.Line[i].Length - 1);
                        item.Line[i + 1] = ",";
                    }
                    else if (item.Line[i].Substring(0, item.Line[i].Length - 1) == ")")
                    {
                        for (int j = 0; j < item.Line[i].Length; j++)
                        {
                            if (item.Line[i].Substring(j, j + 1) == "(")
                            {
                                int x = j;
                                item.Line[i + 1] = "(";

                                if (item.Line[i].Substring(i + 1, 1) == ")")
                                {
                                    item.Line[i + 1] = ")";
                                    continue;
                                }

                                item.Line[i + 2] = item.Line[i].Substring(j, item.Line[i].Length - 1);
                                item.Line[i + 3] = ")";
                                item.Line[i] = item.Line[i].Substring(0, j);
                            }
                        }
                    }
                    else if (item.Line[i].Substring(0, item.Line[i].Length - 1) == "]")
                    {
                        for (int j = 0; j < item.Line[i].Length; j++)
                        {
                            if (item.Line[i].Substring(j, j + 1) == "[")
                            {
                                int x = j;
                                item.Line[i + 3] = "[";

                                if (item.Line[i].Substring(i + 1, 1) == "]")
                                {
                                    item.Line[i + 3] = "]";
                                    continue;
                                }

                                item.Line[i + 2] = item.Line[i].Substring(j, item.Line[i].Length - 1);
                                item.Line[i + 3] = "]";
                                item.Line[i] = item.Line[i].Substring(0, j);
                            }
                        }
                    }
                    else if (item.Line[i].Substring(0, item.Line[i].Length - 1) == "{")
                    {
                        for (int j = 0; j < item.Line[i].Length; j++)
                        {
                            if (item.Line[i].Substring(j, j + 1) == "{")
                            {
                                int x = j;
                                item.Line[i + 3] = "{";

                                if (item.Line[i].Substring(i + 1, 1) == "}")
                                {
                                    item.Line[i + 3] = "}";
                                    continue;
                                }

                                item.Line[i + 2] = item.Line[i].Substring(j, item.Line[i].Length - 1);
                                item.Line[i + 3] = "]";
                                item.Line[i] = item.Line[i].Substring(0, j);
                            }
                        }
                    }
                }
            }
        }
        private void Token()
        {
            foreach (var item in ArgCode)
            {
                for (int i = 0; i < item.Line.Length; i++)
                {
                    if (item.Line.Length == 5)
                    {
                        if (item.Line[i] == "var")
                        {
                            if (item.Line[i + 2] == "=")
                            {
                                if (Num.IsInt(item.Line[i + 3])) intTokens.Add(new IntToken(item.Line[i + 1], Convert.ToInt32(item.Line[i + 3])));
                                else if (Num.IsDouble(item.Line[i + 3])) douTokens.Add(new DoubleToken(item.Line[i + 1], Convert.ToDouble(item.Line[i + 3])));
                                else if (item.Line[i + 3] == "true" || item.Line[i + 3] == "false") boolTokens.Add(new BoolToken(item.Line[i + 1], Convert.ToBoolean(item.Line[i + 3])));
                                else strTokens.Add(new StringToken(item.Line[i + 1], item.Line[i + 3].Substring(1, item.Line[i + 3].Length - 1)));
                            }
                            else Lib.End("Missing Operator");
                        }
                        else if (item.Line[i] == "string") strTokens.Add(new StringToken(item.Line[i + 1], item.Line[i + 3].Substring(1, item.Line[i + 3].Length - 1)));
                        else if (item.Line[i] == "int") intTokens.Add(new IntToken(item.Line[i + 1], Convert.ToInt32(item.Line[i + 3])));
                        else if (item.Line[i] == "double") douTokens.Add(new DoubleToken(item.Line[i + 1], Convert.ToDouble(item.Line[i + 3])));
                        else if (item.Line[i] == "bool") boolTokens.Add(new BoolToken(item.Line[i + 1], Convert.ToBoolean(item.Line[i + 3])));
                        else if (item.Line[i] == "string") strTokens.Add(new StringToken(item.Line[i + 1], item.Line[i + 3].Substring(1, item.Line[i + 3].Length - 1)));
                    }
                }
            }
        }
    }
    internal class Lines
    {
        #region Initialise
        public Lines(string[] line)
        {
            Line = line;
        }
        public Lines(List<string> line) : this(line.ToArray()) { }
        #endregion //Initialise

        #region Properties
        public string[] Line { get; private set; }
        #endregion //Properties
    }
}