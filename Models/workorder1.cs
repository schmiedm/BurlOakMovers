//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BurlOakMovers.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class workorder1
    {
        public int workorderid { get; set; }
        public Nullable<int> custid { get; set; }
        public Nullable<int> numvans { get; set; }
        public Nullable<int> numworker { get; set; }
        public Nullable<double> numhours { get; set; }
        public Nullable<double> payrate { get; set; }
        public Nullable<double> furnishtotal { get; set; }
        public int washer { get; set; }
        public int dryer { get; set; }
        public int fridge { get; set; }
        public int stove { get; set; }
        public int dishwasher { get; set; }
        public int mircowave { get; set; }
        public int freezer { get; set; }
        public string pianotype { get; set; }
        public string wadrobe { get; set; }
        public string mirrorcartons { get; set; }
        public string proposalother { get; set; }
        public Nullable<double> appliancetotal { get; set; }
        public Nullable<bool> deductible { get; set; }
        public Nullable<double> deductibleamount { get; set; }
        public string specialins { get; set; }
        public Nullable<int> labourhrs { get; set; }
        public Nullable<int> carton2 { get; set; }
        public Nullable<int> carton4 { get; set; }
        public Nullable<int> carton5 { get; set; }
        public Nullable<int> smmirror { get; set; }
        public Nullable<int> lgmirror { get; set; }
        public Nullable<int> sglmatress { get; set; }
        public Nullable<int> dblmatress { get; set; }
        public Nullable<int> kingqeen { get; set; }
        public Nullable<int> wardrobes { get; set; }
        public Nullable<int> totalpackestimate { get; set; }
        public string shipper { get; set; }
        public string mover { get; set; }
        public string moverrep { get; set; }
        public Nullable<double> esttotal { get; set; }
        public Nullable<double> taxrate { get; set; }
        public Nullable<double> total { get; set; }
    
        public virtual customer1 customer { get; set; }
    }
}
