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
    
    public partial class ramTypeRequirement
    {
        public int typeID { get; set; }
        public byte activityID { get; set; }
        public int requiredTypeID { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<double> damagePerJob { get; set; }
        public Nullable<bool> recycle { get; set; }
    }
}
