using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITBedrijfProject.Models
{
    public class Register
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Register name")]
        public string RegisterName { get; set; }

        [Required]
        [DisplayName("Device")]
        public string Device { get; set; }

        [Required]
        [DisplayName("Purchase date")]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [DisplayName("Expires date")]
        public DateTime ExpiresDate { get; set; }
    }
}