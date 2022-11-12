namespace UnitedKingdom.Cefas.DataPortal
{
    public class MapOverlay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Uri Url { get; set; }
        public string LayerName { get; set; }
        public bool IsExternal { get; set; }
        public bool IsInternal { get; set; }
        public int Order { get; set; }
    }
}
