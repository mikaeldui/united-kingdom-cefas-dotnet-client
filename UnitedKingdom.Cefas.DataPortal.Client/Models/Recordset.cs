using System;
using System.Collections.Generic;
using System.Text;

namespace UnitedKingdom.Cefas.DataPortal
{
    public class Recordset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Location { get; set; }
        public int HoldingId { get; set; }
        public bool Tabular { get; set; }
        public bool External { get; set; }
        public bool Versioned { get; set; }
        public int Priority { get; set; }
        public int License { get; set; }
        public int Mode { get; set; }
        public bool Draft { get; set; }
        public bool Hidden { get; set; }
        public bool PublishtoOgcEdx { get; set; }
        public object[] Versions { get; set; }
        public object[] Fields { get; set; }
        public object[] Filters { get; set; }
        public Dictionary<string, Link> Links { get; set; }
        public string QouteCharacter { get; set; }
        public string NullString { get; set; }
        public int Srid { get; set; }
        public string KeyFields { get; set; }
        public string TableName { get; set; }
        public int? DeleteddVersion { get; set; }
        public string DeletedBy { get; set; }
    }
}
