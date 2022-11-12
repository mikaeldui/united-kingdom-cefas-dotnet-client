namespace UnitedKingdom.Cefas.DataPortal
{
    public class FieldType
    {
        public string Name { get; set; }

        /// <summary>
        /// E.g. "System.DateTime".
        /// </summary>
        public string DotNetType { get; set; }

        /// <summary>
        /// E.g. "[date]".
        /// </summary>
        public string SqlColumnDef { get; set; }
        public bool AllowRanges { get; set; }
        public bool AllowPatterns { get; set; }
        public bool RequireUnites { get; set; }
        public bool IncludeInData { get; set; }
        /// <summary>
        /// E.g. "Self".
        /// </summary>
        public Dictionary<string, Link> Links { get; set; }
    }
}
