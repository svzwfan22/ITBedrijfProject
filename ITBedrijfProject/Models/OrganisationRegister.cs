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
        public int OrganisationID { get; set; }

        [Required]
        [DisplayName("Organisation name")]
        [StringLength(100, ErrorMessage = "Minimum 2 characters.", MinimumLength = 2)]
        public string OrganisationName { get; set; }

        [Required]
        [DisplayName("Login")]
        [StringLength(100, ErrorMessage = "Minimum 2 characters.", MinimumLength = 2)]
        public string Login { get; set; }

        [Required]
        public int RegisterID { get; set; }

        [Required]
        [DisplayName("Register name")]
        [StringLength(100, ErrorMessage = "Minimum 2 characters.", MinimumLength = 2)]
        public string RegisterName { get; set; }

        [Required]
        [DisplayName("Device")]
        [StringLength(100, ErrorMessage = "Minimum 2 characters.", MinimumLength = 2)]
        public string Device { get; set; }

        [Required]
        [DisplayName("From")]
        public DateTime FromDate { get; set; }

        [Required]
        [DisplayName("Until")]
        public DateTime UntilDate { get; set; }
    }
}