﻿namespace Project
{
    internal class Package
    {
        #region Properties
        public static string MainFile { get; private set; }
        private static List<string> package = new List<string>()
        {
            $"\"name\": \"project\"",
            $"\"author\": \"{System.Security.Principal.WindowsIdentity.GetCurrent().Name}\"",
            $"\"main\": \"index.nv\""
        };
        private static Files packageFile = new Files("package.nir");
        public static List<CodeFiles> ArgCodeFiles { get; private set; }
        #endregion //Properties

        public static void Start()
        {
            if (!File.Exists("package.nir")) packageFile.Save(package);
            else packageFile.Read(out package);

            string[] argPackage = package.ToArray();

            for (int i = 0; i < package.Count; i++)
            {
                if (package[i].Substring(1, 4) == "main") MainFile = package[i].Substring(9, package[i].Length - 10);
            }

            if (!File.Exists(MainFile)) packageFile.Save("c.wl(\"Hello World\")");
        }
        public static void FunCodeFiles()
        {
            string[] argCodeFiles = Directory.GetFiles(@"\", "*.nv", SearchOption.AllDirectories);

            foreach (var item in argCodeFiles)
            {
                ArgCodeFiles.Add();
            }
        }
    }
}
