using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBox_API
{
    public class Provider
    {
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
        public decimal NU_Distance { get; set; }
    }
}