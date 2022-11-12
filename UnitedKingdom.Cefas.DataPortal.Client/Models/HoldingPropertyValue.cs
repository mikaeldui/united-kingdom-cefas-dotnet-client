namespace UnitedKingdom.Cefas.DataPortal
{
    public class HoldingPropertyValue
    {
        /// <summary>
        /// Can be anything from "VertEx:WC" to a GUID and HTML.
        /// </summary>
        public string Value { get; set; }
        public string? DisplayValue { get; set; }

        /// <summary>
        /// E.g. "Definition" or "CodeList".
        /// </summary>
        public Dictionary<string, Link> Links { get; set; }
        public string? Vocabulary { get; set; }
        public string? VocabularyCode { get; set; }
        public bool IsDefault { get; set; }
        public string? VocabularyTitle { get; set; }
        public DateTime? VocabularyDate { get; set; }
        public string? VocabularyDateType { get; set; }
        public string? ExportCode { get; set; }
        public string? ExportName { get; set; }
    }
}
