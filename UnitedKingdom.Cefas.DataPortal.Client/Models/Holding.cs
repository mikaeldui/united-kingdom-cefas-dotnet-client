namespace UnitedKingdom.Cefas.DataPortal
{
    public class Holding
    {
        public int Id { get; set; }
        public int? VersionId { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public int? HoldingType { get; set; }
        public bool? ReadyForApproval { get; set; }
        public string? Status { get; set; }
        public Holding[]? Chrildren { get; set; }
        public HoldingProperty[]? Properties { get; set; }
        public object[]? Recordsets { get; set; }
        public Area Extent { get; set; }
        public int[] Grid { get; set; }
        public Holding[]? Parents { get; set; }
        public Holding[]? Siblings { get; set; }
        public Dictionary<string, Link> Links { get; set; }
    }
}
