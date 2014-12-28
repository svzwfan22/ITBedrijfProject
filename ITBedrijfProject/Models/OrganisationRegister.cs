using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITBedrijfProject.Models
{
    public class OrganisationRegister
    {
        [Required]
        [DisplayName("Organisation")]
        public int OrganisationID { get; set; }

        [Required]
        [DisplayName("Register")]
        public int RegisterID { get; set; }

        [Required]
        [DisplayName("From")]
        public DateTime FromDate { get; set; }

        [Required]
        [DisplayName("Until")]
        public DateTime UntilDate { get; set; }
    }
}