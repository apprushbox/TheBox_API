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
    
    public partial class CreditCard
    {
        public long ID_CreditCard { get; set; }
        public long ID_User { get; set; }
        public string TX_CardNumber { get; set; }
        public string TX_NameOnCard { get; set; }
        public byte NU_ExpirationMonth { get; set; }
        public int NU_ExpirationDay { get; set; }
        public Nullable<bool> BO_Expired { get; set; }
        public Nullable<System.DateTime> DT_Register { get; set; }
    
        public virtual User User { get; set; }
    }
}