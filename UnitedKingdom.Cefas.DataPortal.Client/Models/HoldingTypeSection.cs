namespace UnitedKingdom.Cefas.DataPortal
{
    public class HoldingTypeSection
    {
        public int Id { get; set; }
        public int HoldingTypeId { get; set; }
        public int TabID { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public bool Visible { get; set; }
        public HoldingTypeSectionProperty[] Properties { get; set; }
    }
}
