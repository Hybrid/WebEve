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
    
    public partial class crtRelationship
    {
        public int relationshipID { get; set; }
        public Nullable<int> parentID { get; set; }
        public Nullable<int> parentTypeID { get; set; }
        public Nullable<byte> parentLevel { get; set; }
        public Nullable<int> childID { get; set; }
    }
}
