namespace Project
{
    class ConsoleToken
    {
        public ConsoleToken(string typ, string val)
        {
            Typ = typ;
            Val = val;
        }

        public string Typ { get; }
        public string Val { get; }
    }
    class FunctionToken
    {

    }
    class ClassToken
    {

    }

    #region Var
    class StringToken
    {
        public StringToken(string name, string val)
        {
            Name = name;
            Val = val;
        }

        public string Name { get; }
        public string Val { get; set; }
    }
    class IntToken
    {
        public IntToken(string name, int val)
        {
            Name = name;
            Val = val;
        }

        public string Name { get; }
        public int Val { get; set; }
    }
    class DoubleToken
    {
        public DoubleToken(string name, double val)
        {
            Name = name;
            Val = val;
        }

        public string Name { get; }
        public double Val { get; set; }
    }
    class BoolToken
    {
        public BoolToken(string name, bool val)
        {
            Name = name;
            Val = val;
        }

        public string Name { get; }
        public bool Val { get; set; }
    }
    #endregion //Var
}
