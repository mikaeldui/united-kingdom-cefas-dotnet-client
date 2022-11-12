namespace UnitedKingdom.Cefas.DataPortal
{
    public class Property
    {
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Type { get; set; }
        /// <summary>
        /// Can be HTML.
        /// </summary>
        public string GeneralDescription { get; set; }
        public bool MdrViewerInternal { get; set; }
        public bool MdrViewerExternal { get; set; }
        public bool MdrSearchInternal { get; set; }
        public bool MeedinExport { get; set; }
        public string ExportName { get; set; }
        public int EditPermission { get; set; }
        public PropertyVocabulary[] PropertyVocabularies { get; set; }
        public Dictionary<string, Link> Links { get; set; }
    }
}
