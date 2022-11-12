using System;
using System.Collections.Generic;
using System.Text;

namespace UnitedKingdom.Cefas.DataPortal
{
    public class Page<TItem>
    {
        /// <summary>
        /// E.g. "Self" or "Recordsset".
        /// </summary>
        public Dictionary<string, Link> Links { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        /// <summary>
        /// E.g. "20".
        /// </summary>
        public int ItemsPerPage { get; set; }
        public TItem[] Items { get; set; }
    }
}
