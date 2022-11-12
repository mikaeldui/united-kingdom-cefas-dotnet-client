namespace UnitedKingdom.Cefas.DataPortal
{
    public class PropertyVocabulary
    {
        public string Vocabulary { get; set; }
        public int Order { get; set; }
        public Dictionary<string, Link> Links { get; set; }
    }
}
