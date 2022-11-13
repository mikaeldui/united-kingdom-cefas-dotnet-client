namespace UnitedKingdom.Cefas.DataPortal
{
    public class WafHolding
    {
        public int HoldingId { get; set; }
        public DateTime StartDate { get; set; }
        /// <summary>
        /// E.g. "Meta:data.cefas.co.uk".
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// E.g. "Blackwater Herring Survey (FSS: INA K HER)".
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Can be HTML.
        /// </summary>
        public string Description { get; set; }
    }
}
