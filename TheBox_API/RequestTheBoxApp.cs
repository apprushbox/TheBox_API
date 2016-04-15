using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBox_API
{
    public class RequestTheBoxApp
    {
        public string Text { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public long ID_Provider { get; set; }

    }
}