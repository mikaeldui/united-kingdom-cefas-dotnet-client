namespace UnitedKingdom.Cefas.DataPortal
{
    public class HoldingTypeSectionProperty
    {
        public int HoldingTypeId { get; set; }
        public int Section { get; set; }
        public int Order { get; set; }
        public string PropertyName { get; set; }
        public string LongName { get; set; }
        public string Widget { get; set; }
        public bool Required { get; set; }
        public string ExportName { get; set; }
        public string SectionName { get; set; }
        public string[] Vocabularies { get; set; }
        public string DefaultValue { get; set; }
        public string HelpText { get; set; }
        public string LookupTable { get; set; }
    }
}
