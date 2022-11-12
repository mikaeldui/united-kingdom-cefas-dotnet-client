namespace UnitedKingdom.Cefas.DataPortal
{
    public class Keyword
    {
        public int? HoldingCount { get; set; }
        /// <summary>
        /// Same as Name.
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Same as Value.
        /// </summary>
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Vocabulary { get; set; }
        public bool? Searchable { get; set; }
        public string? VocabularyCode { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Order { get; set; }
        public Uri? DefinitionLink { get; set; }
    }
}
