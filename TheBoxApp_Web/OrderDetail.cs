//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TheBoxApp_Web
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetail
    {
        public long ID_Detail { get; set; }
        public long ID_Order { get; set; }
        public long ID_Product { get; set; }
        public decimal NU_Price { get; set; }
        public int NU_Quantity { get; set; }
        public decimal NU_Total { get; set; }
        public Nullable<System.DateTime> DT_Register { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
