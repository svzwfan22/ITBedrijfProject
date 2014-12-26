using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITBedrijfProject.Models
{
    public class OrganisationRegister
    {
        public int OrganisationID { get; set; }
        public int RegisterID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime UntilDate { get; set; }
    }
}