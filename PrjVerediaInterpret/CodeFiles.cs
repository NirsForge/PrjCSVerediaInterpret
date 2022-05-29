namespace Project
{
    internal class CodeFiles
    {
        #region Initialise
        public CodeFiles(string paf)
        {
            var file = new Files(paf);
            file.Read(out code);

            for (int i = 0; i < code.Count; i++)
            {
                if (code[i].Length >= 2)
                    if (code[i].Substring(0,2) == "//") code.RemoveAt(i);
            }
        }
        #endregion //Initialise

        #region Properties
        private List<string> code;
        #endregion //Properties
    }
}
