namespace UnitedKingdom.Cefas.DataPortal
{
    public class FilterType
    {
        /// <summary>
        /// E.g. "After".
        /// </summary>
        public string LongName { get; set; }

        /// <summary>
        /// E.g. "af".
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// E.g. "1".
        /// </summary>
        public int? Operands { get; set; }

        /// <summary>
        /// E.g. "DateTime".
        /// </summary>
        public string? OperandType { get; set; }
    }
}
