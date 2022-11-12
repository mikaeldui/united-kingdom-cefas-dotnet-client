namespace UnitedKingdom.Cefas.DataPortal
{
    public class Location
    {
        public int Id { get; set; }
        /// <summary>
        /// E.g. "Microsoft.Data.SqlClient".
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// E.g. "MDRExternalStorage".
        /// </summary>
        public string Name { get; set; }
        public string Description { get; set; }
        public bool AcceptsTables { get; set; }
        public bool AcceptsBlobs { get; set; }
        public bool IsExternal { get; set; }
        public bool IsThisDatabase { get; set; }
        public string Details { get; set; }
        public bool ReadOnly { get; set; }
        /// <summary>
        /// E.g. ""Recordset_".
        /// </summary>
        public string TableNamePrefix { get; set; }
        /// <summary>
        /// E.g. ""MDRExternalStorage".
        /// </summary>
        public string Schema { get; set; }
        public bool Georeferencable { get; set; }
    }
}
