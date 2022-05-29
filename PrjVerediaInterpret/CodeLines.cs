namespace Project
{
    internal class CodeLine
    {
        #region Initialise
        public CodeLine(string[] line)
        {
            Line = line;
        }
        public CodeLine(List<string> line) : this(line.ToArray()) { }
        #endregion //Initialise

        #region Properties
        public string[] Line { get; private set; }
        #endregion //Properties
    }
}
