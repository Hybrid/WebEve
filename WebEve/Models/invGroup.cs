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
    
    public partial class invGroup
    {
        public int groupID { get; set; }
        public Nullable<int> categoryID { get; set; }
        public string groupName { get; set; }
        public string description { get; set; }
        public Nullable<int> iconID { get; set; }
        public Nullable<bool> useBasePrice { get; set; }
        public Nullable<bool> allowManufacture { get; set; }
        public Nullable<bool> allowRecycler { get; set; }
        public Nullable<bool> anchored { get; set; }
        public Nullable<bool> anchorable { get; set; }
        public Nullable<bool> fittableNonSingleton { get; set; }
        public Nullable<bool> published { get; set; }
    }
}
