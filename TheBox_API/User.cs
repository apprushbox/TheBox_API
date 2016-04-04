using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBox_API
{
    public class User
    {
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
    }
}