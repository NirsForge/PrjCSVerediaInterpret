using LibCS._Lib.Parse;

namespace LibCS
{
    public class Lib
    {
        #region Properties
        private static string Color { get; set; }
        #endregion //Properties

        #region Color
        public static void TxtColor(string color = "07")
        {
            if (color.Length != 2) return;

            Color = color;

            TxtColor(Hex(color.Substring(1, 1)), Hex(color.Substring(0, 1)));
        }
        public static void Rainbow(string txt)
        {
            string[] color = { "0C", "0E", "0A", "09", "05" };
            int arr = 0, argI = txt.Length;

            if (txt.Substring(txt.Length - 2, 2) == "\n") argI = txt.Length - 2;

            for (int i = 0; i < argI; i++)
            {
                if (txt.Substring(i, 1) == " ")
                {
                    Console.Write(" ");
                    continue;
                }

                TxtColor(color[arr]);
                Console.Write(txt.Substring(i, 1));

                if (arr == 4) arr = -1;

                arr++;
            }

            TxtColor();
        }
        private static void TxtColor(int f, int b)
        {
            switch (f)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 10:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 11:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 12:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 13:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 14:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 15:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }

            switch (b)
            {
                case 0:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case 1:
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;
                case 2:
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
                case 3:
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    break;
                case 4:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                case 5:
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 6:
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    break;
                case 7:
                    Console.BackgroundColor = ConsoleColor.Gray;
                    break;
                case 8:
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case 9:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case 10:
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case 11:
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;
                case 12:
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case 13:
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    break;
                case 14:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                case 15:
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
            }
        }
        #endregion //Color

        #region Read
        public static string Read(string ask = "Insert Value!", string pref = "> ")
        {
            Console.WriteLine(ask);
            Console.Write(pref);
            return Console.ReadLine();
        }
        public static string Read(string[] val, string ask = "Insert Value!", string pref = "> ")
        {
            bool test = false;
            string input;

            do
            {
                input = Read(ask);

                for (int i = 0; i < val.Length; i++)
                {
                    if (input == val[i])
                        test = true;
                }

                Border();
            } while (!test);

            return input;
        }
        #endregion //Read

        #region Key
        public static ConsoleKey Key(string ask = "Use a button!", string pref = "> ")
        {
            if (ask == null) ask = "Gib einen Wert ein!";

            Console.Write(ask + "\n" + pref);
            return Console.ReadKey().Key;
        }
        public static ConsoleKey Key(string[] val, string ask = "Use a button!", string pref = "> ")
        {
            ConsoleKey input;
            bool test = false;

            do
            {
                input = Key(ask, pref);

                for (int i = 0; i < val.Length; i++)
                {
                    if (Convert.ToString(input) == val[i])
                        test = true;
                }

                Border();
            } while (!test);

            return input;
        }
        #endregion //Key

        private static int Hex(string arg)
        {
            if (arg == null) return 0;

            string[] val = { "A", "B", "C", "D", "E", "F" };
            bool test = false;

            foreach (var item in val)
            {
                if (arg == item || Num.IsNum(arg))
                {
                    test = true;
                    break;
                }

                test = false;
            }

            if (!test) return 0;

            if (arg == "A") return 10;
            if (arg == "B") return 11;
            if (arg == "C") return 12;
            if (arg == "D") return 13;
            if (arg == "E") return 14;
            if (arg == "F") return 15;

            return Convert.ToInt32(arg);
        }
        public static string Border(string typ = "c2")
        {
            switch (typ)
            {
                case "c1":
                    Console.WriteLine(Border("s1"));
                    break;
                case "c2":
                    Console.WriteLine(Border("s2"));
                    break;
                case "c3":
                    Console.WriteLine(Border("s3"));
                    break;
                case "s1":
                    return "_____________________";
                case "s2":
                    return "---------------------";
                case "s3":
                    return ".....................";
                default:
                    break;
            }

            return "";
        }
        public static void End(string ask = "Press any key to end the programm...")
        {
            TxtColor();
            Border("c1");
            Key(ask, "");
            TxtColor("00");
            Environment.Exit(0);
        }
    }
}