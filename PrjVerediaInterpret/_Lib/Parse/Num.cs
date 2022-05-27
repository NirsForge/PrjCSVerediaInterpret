namespace LibCS
{
    public class Num
    {
        #region Properties
        private static string Out { get; set; }
        private static bool Test { get; set; }
        #endregion //Properties

        #region Int
        public static bool IsInt(string input)
        {
            return int.TryParse(input, out int x);
        }
        public static int Int(out int output, string ask = "Enter int value")
        {
            do
            {
                Out = Lib.Read(ask);
                Test = IsInt(Out);
                Lib.Border("c3");
            } while (!Test);

            return output = Convert.ToInt32(Out);
        }
        public static int Int(string numbField, out int output, string ask = "Enter int value")
        {
            switch (numbField)
            {
                case "+":
                    do
                    {
                        Int(out output, ask);
                    } while (output < 0);
                    break;
                case "-":
                    do
                    {
                        Int(out output, ask);
                    } while (output > 0);
                    break;
                default:
                    Console.WriteLine("Invalid Argument!");
                    output = 0;
                    break;
            }

            return output;
        }
        public static int Int(int[] minMax, out int output, string ask = "Enter int value")
        {
            if (minMax.Length != 2) return output = 0;

            do
            {
                Int(out output, ask);
            } while (output > minMax[0] || output < minMax[1]);

            return output;
        }
        public static int Int(List<string> val, out int output, string ask = "Enter int value")
        {
            do
            {
                Int(out output, ask);

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
        #endregion //Int

        #region Double
        public static bool IsDouble(string input)
        {
            return double.TryParse(input, out double x);
        }
        public static double Double(out double output, string ask = "Enter double value")
        {
            do
            {
                Out = Lib.Read(ask);
                Test = IsDouble(Out);
                Lib.Border("c3");
            } while (!Test);

            return output = Convert.ToDouble(Out);
        }
        public static double Double(string numbField, out double output, string ask = "Enter double value")
        {
            switch (numbField)
            {
                case "+":
                    do
                    {
                        Double(out output, ask);
                    } while (output < 0);
                    break;
                case "-":
                    do
                    {
                        Double(out output, ask);
                    } while (output > 0);
                    break;
                default:
                    Console.WriteLine("Invalid Argument");
                    output = 0;
                    break;
            }

            return output;
        }
        public static double Double(double[] minMax, out double output, string ask = "Enter double value")
        {
            if (minMax.Length != 2) return output = 0;

            do
            {
                Double(out output, ask);
            } while (output > minMax[0] || output < minMax[1]);

            return output;
        }
        public static double Double(List<string> val, out double output, string ask = "Enter double value")
        {
            do
            {
                Double(out output, ask);

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
        #endregion //Double

        #region Float
        public static bool IsFloat(string input)
        {
            return float.TryParse(input, out float x);
        }
        public static float Float(out float output, string ask = "Enter int value")
        {
            do
            {
                Out = Lib.Read(ask);
                Test = IsFloat(Out);
                Lib.Border("c3");
            } while (!Test);

            return output = Convert.ToSingle(Out);
        }
        public static float Float(string numbField, out float output, string ask = "Enter int value")
        {
            switch (numbField)
            {
                case "+":
                    do
                    {
                        Float(out output, ask);
                    } while (output < 0);
                    break;
                case "-":
                    do
                    {
                        Float(out output, ask);
                    } while (output > 0);
                    break;
                default:
                    Console.WriteLine("Invalid Argument!");
                    output = 0;
                    break;
            }

            return output;
        }
        public static float Float(int[] minMax, out float output, string ask = "Enter int value")
        {
            if (minMax.Length != 2) return output = 0;

            do
            {
                Float(out output, ask);
            } while (output > minMax[0] || output < minMax[1]);

            return output;
        }
        public static float Float(List<string> val, out float output, string ask = "Enter int value")
        {
            do
            {
                Float(out output, ask);

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
        #endregion //Float

        public static bool IsNum(string input)
        {
            if (IsDouble(input) || IsInt(input) || IsFloat(input)) return true;

            return false;
        }
    }
}
