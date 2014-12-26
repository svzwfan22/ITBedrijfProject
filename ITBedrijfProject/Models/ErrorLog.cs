using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITBedrijfProject.Models
{
    public class Errorlog
    {
        public int RegisterID { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public string Stacktrace { get; set; }
    }
}