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
    
    public partial class walletTransaction
    {
        public long transID { get; set; }
        public Nullable<System.DateTime> transDate { get; set; }
        public Nullable<long> transRef { get; set; }
        public string transKey { get; set; }
        public Nullable<double> quantity { get; set; }
        public string typeName { get; set; }
        public Nullable<int> typeID { get; set; }
        public Nullable<int> groupID { get; set; }
        public Nullable<int> categoryID { get; set; }
        public Nullable<int> marketgroupID { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable<long> clientID { get; set; }
        public string clientName { get; set; }
        public Nullable<long> stationID { get; set; }
        public string stationName { get; set; }
        public string transType { get; set; }
        public string transFor { get; set; }
        public Nullable<long> systemID { get; set; }
        public Nullable<long> constID { get; set; }
        public Nullable<long> regionID { get; set; }
        public Nullable<long> charID { get; set; }
        public string charName { get; set; }
        public Nullable<int> walletID { get; set; }
        public Nullable<System.DateTime> importDate { get; set; }
    }
}
