namespace LibCS
{
    internal class Date
    {
        #region Properties
        private static string Out { get; set; }
        private static bool Test { get; set; }
        #endregion //Properties

        public static bool IsDate(string input)
        {
            if (IsTime(input) || IsOnly(input)) return true;

            return false;
        }

        #region DateTime
        public static bool IsTime(string input)
        {
            return DateTime.TryParse(input, out DateTime x);
        }
        public static DateTime Time(out DateTime output, string ask = "Enter DateTime value")
        {
            do
            {
                Out = Lib.Read(ask);
                Test = IsTime(Out);
                Lib.Border("c3");
            } while (!Test);

            return output = Convert.ToDateTime(Out);
        }
        public static DateTime Time(List<string> val, out DateTime output, string ask = "Enter DateTime value")
        {
            do
            {
                Time(out output, ask);

                foreach (var item in val)
                {
                    if (Convert.ToString(output) == item)
                    {
                        Test = true;
                        break;
                    }

                    Test = false;
                }
            } while (!Test);

            return output;
        }
        #endregion //DateTime

        #region DateOnly
        public static bool IsOnly(string input)
        {
            return DateOnly.TryParse(input, out DateOnly x);
        }
        public static DateOnly Only(out DateOnly output, string ask = "Enter DateTime value")
        {
            do
            {
                Out = Lib.Read(ask);
                Test = IsOnly(Out);
                Lib.Border("c3");
            } while (!Test);

            return output = DateOnly.FromDateTime(Convert.ToDateTime(Out));
        }
        public static DateOnly Only(List<string> val, out DateOnly output, string ask = "Enter DateTime value")
        {
            do
            {
                Only(out output, ask);

                foreach (var item in val)
                {
                    if (Convert.ToString(output) == item)
                    {
                        Test = true;
                        break;
                    }

                    Test = false;
                }
            } while (!Test);

            return output;
        }
        #endregion //DateOnly
    }
}
