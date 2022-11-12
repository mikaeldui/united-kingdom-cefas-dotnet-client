namespace UnitedKingdom.Cefas.DataPortal
{
    public class CollectionStatus
    {
        public int Id { get; set; }
        /// <summary>
        /// E.g. "Cefas_Plankton_Imager_Data_2016_2019.csv".
        /// </summary>
        public string Name { get; set; }
        public int CachedLocations { get; set; }
    }
}
