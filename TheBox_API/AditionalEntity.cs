//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TheBox_API
{
    using System;
    using System.Collections.Generic;
    
    public partial class AditionalEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AditionalEntity()
        {
            this.ProductAditionals = new HashSet<ProductAditionalEntity>();
        }
    
        public long ID_Aditional { get; set; }
        public string TX_Aditional { get; set; }
        public Nullable<bool> BO_Active { get; set; }
        public Nullable<System.DateTime> DT_Register { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductAditionalEntity> ProductAditionals { get; set; }
    }
}
