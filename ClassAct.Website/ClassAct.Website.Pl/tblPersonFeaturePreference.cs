//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassAct.Website.Pl
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPersonFeaturePreference
    {
        public int PersonID { get; set; }
        public int FeatureID { get; set; }
        public Nullable<double> Rating { get; set; }
    
        public virtual tblFeature tblFeature { get; set; }
    }
}