using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBox_API
{
    public class CreditCard
    {
        public long ID_CreditCard { get; set; }
        public long ID_User { get; set; }
        public string TX_CardNumber { get; set; }
        public string TX_NameOnCard { get; set; }
        public byte NU_ExpirationMonth { get; set; }
        public int NU_ExpirationDay { get; set; }
        public Nullable<bool> BO_Expired { get; set; }
        public Nullable<System.DateTime> DT_Register { get; set; }
        public bool BO_Active { get; set; }
    }
}