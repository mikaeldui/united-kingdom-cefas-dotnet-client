namespace UnitedKingdom.Cefas.DataPortal
{
    public class Vocabulary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Format { get; set; }
        public string ExportTitle { get; set; }
        public DateTime ExportDate { get; set; }
        public string ExportDateType { get; set; }
        public bool Searchable { get; set; }
        public string Prefix { get; set; }
        public Keyword[] Keywords { get; set; }
    }
}
