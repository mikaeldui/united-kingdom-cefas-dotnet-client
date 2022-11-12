namespace UnitedKingdom.Cefas.DataPortal
{
    public class File
    {
        public int Id { get; set; }
        public DateTime UploadDead { get; set; }
        public string Format { get; set; }
        public string ContentType { get; set; }
        public int RecordsetId { get; set; }
        public string Filename { get; set; }

        /// <summary>
        /// E.g. "F853EDD0B107E50F1830D0F4D86EC0A9".
        /// </summary>
        public string Checksum { get; set; }

        public int Mode { get; set; }

        /// <summary>
        /// E.g. "ab7168d3-58cb-4bdb-9b94-c2da8e5ba1af.DataReadMe..txt".
        /// </summary>
        public string BlobStorageReference { get; set; }

        public bool Geometryconverted { get; set; }
        public int FileStatus { get; set; }
        public int Rows { get; set; }
        public int Size { get; set; }
        public int ImportVersion { get; set; }
        public bool Deleted { get; set; }
    }
}
