//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM_Demo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tapahtumat
    {
        public int TapahtumaId { get; set; }
        public Nullable<int> AsiakasId { get; set; }
        public Nullable<int> TapahtumalajiId { get; set; }
        public Nullable<System.DateTime> TapahtumaPvm { get; set; }
        public Nullable<System.DateTime> TapahtumaKlo { get; set; }
        public string TapahtumaKuvaus { get; set; }
    
        public virtual Asiakkaat Asiakkaat { get; set; }
        public virtual Tapahtumalajit Tapahtumalajit { get; set; }
    }
}
