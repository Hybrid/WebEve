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
    
    public partial class eveGraphic
    {
        public int graphicID { get; set; }
        public string graphicFile { get; set; }
        public string description { get; set; }
        public bool obsolete { get; set; }
        public string graphicType { get; set; }
        public Nullable<bool> collidable { get; set; }
        public Nullable<int> explosionID { get; set; }
        public Nullable<int> directoryID { get; set; }
        public string graphicName { get; set; }
    }
}
