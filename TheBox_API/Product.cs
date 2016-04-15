using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBox_API
{
    public class Product
    {
        public long ID_Product { get; set; }
        public long ID_Provider { get; set; }
        public long ID_ProductCategory { get; set; }
        public string TX_Name { get; set; }
        public string TX_Description { get; set; }
        public decimal NU_Price { get; set; }
        public decimal NU_ShippingCost { get; set; }
        public bool BO_SpecialOffer { get; set; }
        public bool BO_Service { get; set; }
        public byte[] IM_Image { get; set; }
        public Nullable<bool> BO_Active { get; set; }
        public Nullable<System.DateTime> DT_Register { get; set; }
    }
}