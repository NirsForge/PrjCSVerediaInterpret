namespace LibCS
{
    //File.Replace();

    internal class Files
    {
        #region Initialise
        public Files(string paf)
        {
            Paf = paf;

            Exists();
        }
        public Files() : this("data.md") { }
        #endregion //Initialise

        #region Properties
        public string Paf { get; set; }
        #endregion //Properties

        #region Save
        public void Save(string[] lines)
        {
            Exists();

            File.WriteAllLines(Paf, lines);
        }
        public void Save(List<string> lines)
        {
            Exists();

            File.WriteAllLines(Paf, lines);
        }
        public void Save(string txt)
        {
            Exists();

            File.WriteAllText(Paf, txt);
        }
        #endregion //Save

        #region Append
        public void Append(string[] lines)
        {
            Exists();

            File.AppendAllLines(Paf, lines);
        }
        public void Append(List<string> lines)
        {
            Exists();

            File.AppendAllLines(Paf, lines);
        }
        public void Append(string txt)
        {
            Exists();

            File.AppendAllText(Paf, txt);
        }
        #endregion //Append

        #region Read
        public void Read(out string[] lines)
        {
            Exists();

            lines = File.ReadAllLines(Paf);
        }
        public void Read(out List<string> lines)
        {
            Exists();

            lines = File.ReadAllLines(Paf).ToList();
        }
        public void Read(out string txt)
        {
            Exists();

            txt = File.ReadAllText(Paf);
        }
        #endregion //Read

        public void Exists()
        {
            if (!File.Exists(Paf)) File.Create(Paf).Close();
        }
        public void Delete()
        {
            Exists();

            File.Delete(Paf);
        }
        public void Move(string destination)
        {
            Exists();

            File.Move(Paf, destination);

            Paf = destination;
        }
        public void Copy(string destination)
        {
            Exists();

            File.Copy(Paf, destination);
        }
        private DateOnly LastUsed()
        {
            Exists();

            return DateOnly.FromDateTime(File.GetLastWriteTime(Paf));
        }
    }
}
