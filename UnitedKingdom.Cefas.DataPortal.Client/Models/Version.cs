namespace UnitedKingdom.Cefas.DataPortal
{
    public class Version
    {
        public int Id { get; set; }
        public int recordsetId { get; set; }
        public DateTime Date { get; set; }
        public bool IsReady { get; set; }
        public int RecordsAdded { get; set; }
        public int RecordsRemoved { get; set; }
        public int ActiveRecords { get; set; }
        public int TotalRecords { get; set; }
    }
}
