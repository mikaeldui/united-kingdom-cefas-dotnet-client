namespace UnitedKingdom.Cefas.DataPortal
{
    public class Licence : Link
    {
        /// <summary>
        /// E.g. "1".
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// E.g. "Open Government Licence".
        /// </summary>
        public string Name { get; set; }
    }
}
