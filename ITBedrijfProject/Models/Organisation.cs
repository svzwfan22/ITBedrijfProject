using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ITBedrijfProject.Models
{
    public class Organisation
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Login")]
        public string Login { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Database name")]
        public string DbName { get; set; }

        [Required]
        [DisplayName("Login Database")]
        public string DbLogin { get; set; }

        [Required]
        [DisplayName("Database password")]
        public string DbPassword { get; set; }

        [Required]
        [DisplayName("Naam Organisatie")]
        public string OrganisationName { get; set; }

        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Phone")]
        public string Phone { get; set; }
    }
}