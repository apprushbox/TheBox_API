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
    
    public partial class UserEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserEntity()
        {
            this.Providers = new HashSet<ProviderEntity>();
            this.CreditCards = new HashSet<CreditCardEntity>();
        }
    
        public long ID_User { get; set; }
        public string TX_Name { get; set; }
        public string TX_LastName { get; set; }
        public string TX_Email { get; set; }
        public string TX_UserName { get; set; }
        public string TX_Password { get; set; }
        public string TX_PhoneNumber { get; set; }
        public Nullable<bool> BO_Provider { get; set; }
        public Nullable<bool> BO_Active { get; set; }
        public Nullable<System.DateTime> DT_Register { get; set; }
        public byte[] IM_Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProviderEntity> Providers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CreditCardEntity> CreditCards { get; set; }
    }
}
