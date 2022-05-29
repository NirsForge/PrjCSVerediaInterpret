namespace Project
{
    internal class CodeLines
    {
        #region Initialise
        public CodeLines(string[] line)
        {
            Line = line;
        }
        public CodeLines(List<string> line) : this(line.ToArray()) { }
        #endregion //Initialise

        #region Properties
        public string[] Line { get; private set; }
        #endregion //Properties
    }
}
