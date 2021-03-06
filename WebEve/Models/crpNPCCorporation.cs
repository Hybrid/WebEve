//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebEve.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class crpNPCCorporation
    {
        public int corporationID { get; set; }
        public string size { get; set; }
        public string extent { get; set; }
        public Nullable<int> solarSystemID { get; set; }
        public Nullable<int> investorID1 { get; set; }
        public Nullable<byte> investorShares1 { get; set; }
        public Nullable<int> investorID2 { get; set; }
        public Nullable<byte> investorShares2 { get; set; }
        public Nullable<int> investorID3 { get; set; }
        public Nullable<byte> investorShares3 { get; set; }
        public Nullable<int> investorID4 { get; set; }
        public Nullable<byte> investorShares4 { get; set; }
        public Nullable<int> friendID { get; set; }
        public Nullable<int> enemyID { get; set; }
        public Nullable<long> publicShares { get; set; }
        public Nullable<int> initialPrice { get; set; }
        public Nullable<double> minSecurity { get; set; }
        public Nullable<bool> scattered { get; set; }
        public Nullable<byte> fringe { get; set; }
        public Nullable<byte> corridor { get; set; }
        public Nullable<byte> hub { get; set; }
        public Nullable<byte> border { get; set; }
        public Nullable<int> factionID { get; set; }
        public Nullable<double> sizeFactor { get; set; }
        public Nullable<short> stationCount { get; set; }
        public Nullable<short> stationSystemCount { get; set; }
        public string description { get; set; }
        public Nullable<int> iconID { get; set; }
    }
}
