namespace UnitedKingdom.Cefas.DataPortal
{
    public class Record
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public string FileType { get; set; }
        public int SourceFile { get; set; }
        public Dictionary<string, Link> Links { get; set; }
        public int CreatedVersion { get; set; }
    }
}