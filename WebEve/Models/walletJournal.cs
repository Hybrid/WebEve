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
    
    public partial class walletJournal
    {
        public long transID { get; set; }
        public Nullable<System.DateTime> transDate { get; set; }
        public Nullable<long> transRef { get; set; }
        public string transKey { get; set; }
        public Nullable<int> refTypeID { get; set; }
        public string ownerName1 { get; set; }
        public Nullable<long> ownerID1 { get; set; }
        public string ownerName2 { get; set; }
        public Nullable<long> ownerID2 { get; set; }
        public string argName1 { get; set; }
        public Nullable<long> argID1 { get; set; }
        public Nullable<double> amount { get; set; }
        public Nullable<double> balance { get; set; }
        public string reason { get; set; }
        public Nullable<long> taxID { get; set; }
        public Nullable<double> taxAmount { get; set; }
        public Nullable<long> charID { get; set; }
        public string charName { get; set; }
        public Nullable<int> walletID { get; set; }
        public Nullable<System.DateTime> importDate { get; set; }
    }
}
