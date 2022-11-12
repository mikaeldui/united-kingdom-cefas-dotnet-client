namespace UnitedKingdom.Cefas.DataPortal
{
    public class LocationStatus
    {
        /// <summary>
        /// E.g. "Smartbuoy".
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// E.g. "Microsoft.Data.SqlClient".
        /// </summary>
        public string Type { get; set; }
        public bool AbleToConnect { get; set; }
        public bool ExternallyAccessible { get; set; }
        public Dictionary<string, int>? RecordsetNumbers { get; set; }
        public string[]? BrokenRecordsets { get; set; }
        public string[]? MissingTables { get; set; }
        public string[]? OrphanedTables { get; set; }
    }
}
