namespace Project
{
    internal class CodeFiles
    {
        #region Initialise
        public CodeFiles(string paf)
        {
            Paf = paf;
            var file = new Files(Paf);
            file.Read(out code);

            for (int i = 0; i < code.Count; i++)
            {
                if (code[i].Length >= 2)
                    if (code[i].Substring(0,2) == "//") code.RemoveAt(i);
            }

            if (Missing()) Lib.End("Error: Missing argument");
        }
        #endregion //Initialise

        #region Properties
        private string Paf { get; }
        private List<string> code;
        private List<CodeLine> argCode;
        #endregion //Properties

        private bool Missing()
        {
            List<int> clamp = new List<int>() { 0, 0, 0 }; //{ "{}", "[]", "()" }

            foreach (var item in code)
            {
                if (item == "{")
                    clamp[0]++;
                else if (item == "}")
                    clamp[0]--;
                else if (item == "[")
                    clamp[1]++;
                else if (item == "]")
                    clamp[1]--;
                else if (item == "(")
                    clamp[2]++;
                else if (item == ")")
                    clamp[2]--;
            }

            if (clamp[0] < 0) return true;
            else if (clamp[0] > 0) return true;

            if (clamp[1] < 0) return true;
            else if (clamp[1] > 0) return true;

            if (clamp[2] < 0) return true;
            else if (clamp[2] > 0) return true;

            return false;
        }
        private void Split()
        {
            foreach (var line in code)
            {
                argCode.Add(new CodeLine(line.Split(" ")));
            }

            foreach (var item in argCode)
            {
                for (int i = 0; i < item.Line.Count(); i++)
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
    }
}
