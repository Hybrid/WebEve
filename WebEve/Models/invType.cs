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
    
    public partial class invType
    {
        public int typeID { get; set; }
        public Nullable<int> groupID { get; set; }
        public string typeName { get; set; }
        public string description { get; set; }
        public Nullable<int> graphicID { get; set; }
        public Nullable<double> radius { get; set; }
        public Nullable<double> mass { get; set; }
        public Nullable<double> volume { get; set; }
        public Nullable<double> capacity { get; set; }
        public Nullable<int> portionSize { get; set; }
        public Nullable<byte> raceID { get; set; }
        public Nullable<decimal> basePrice { get; set; }
        public Nullable<bool> published { get; set; }
        public Nullable<short> marketGroupID { get; set; }
        public Nullable<double> chanceOfDuplicating { get; set; }
        public Nullable<int> iconID { get; set; }
    }
}
