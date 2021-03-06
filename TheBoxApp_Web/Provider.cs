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
    
    public partial class Provider
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Provider()
        {
            this.Products = new HashSet<Product>();
            this.Distances = new HashSet<Distance>();
        }
    
        public long ID_Provider { get; set; }
        public long ID_User { get; set; }
        public string TX_Name { get; set; }
        public string TX_AddressLine1 { get; set; }
        public string TX_AddressLine2 { get; set; }
        public int ID_Country { get; set; }
        public long ID_City { get; set; }
        public string TX_StateProvinceRegion { get; set; }
        public string TX_Zip { get; set; }
        public string TX_PhoneNumber { get; set; }
        public Nullable<System.DateTime> DT_Register { get; set; }
        public bool BO_Open { get; set; }
        public System.Data.Entity.Spatial.DbGeography GE_Location { get; set; }
        public Nullable<double> NU_Latitude { get; set; }
        public Nullable<double> NU_Longitud { get; set; }
    
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Distance> Distances { get; set; }
    }
}
