//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProgPOE
{
    using System;
    using System.Collections.Generic;
    
    public partial class FarmerProduct
    {
        public int fpID { get; set; }
        public string farmer_cell { get; set; }
        public string product_code { get; set; }
    
        public virtual Farmer Farmer { get; set; }
        public virtual Product Product { get; set; }
    }
}
