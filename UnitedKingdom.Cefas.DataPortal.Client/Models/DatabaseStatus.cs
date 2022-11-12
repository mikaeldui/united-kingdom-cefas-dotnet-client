namespace UnitedKingdom.Cefas.DataPortal
{
    public class DatabaseStatus
    {
        public bool AbleToConnect { get; set; }
        public Statistics[] Counts { get; set; }
        public bool AbleToExtractCounts { get; set; }
    }
}
