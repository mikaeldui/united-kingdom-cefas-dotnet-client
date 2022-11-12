namespace UnitedKingdom.Cefas.DataPortal
{
    public class ServiceStatus
    {
        public Uri Location { get; set; }
        public int ResponseCount { get; set; }
        public TimeSpan ResponseTime { get; set; }
        public int ResponseSize { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseStatus { get; set; }
        public bool AbleToConnect { get; set; }
    }
}
