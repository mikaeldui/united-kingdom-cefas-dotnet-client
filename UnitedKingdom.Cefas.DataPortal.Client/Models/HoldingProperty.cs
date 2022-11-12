namespace UnitedKingdom.Cefas.DataPortal
{
    public class HoldingProperty
    {
        public string Section { get; set; }
        public string PropertyName { get; set; }
        public string PropertyDisplayName { get; set; }
        public string? ExportName { get; set; }
        public string Widget { get; set; }
        public HoldingPropertyValue[] Values { get; set; }
    }
}
