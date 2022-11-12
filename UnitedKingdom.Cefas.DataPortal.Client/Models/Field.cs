namespace UnitedKingdom.Cefas.DataPortal
{
    public class Field
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ColumnName { get; set; }
        public int? Sequence { get; set; }
        public string? Units { get; set; }
    }
}
