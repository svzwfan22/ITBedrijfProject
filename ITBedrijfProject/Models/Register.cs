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
        [StringLength(100, ErrorMessage = "Minimum 2 characters.", MinimumLength = 2)]

        public string RegisterName { get; set; }

        [Required]
        [DisplayName("Device")]
        [StringLength(100, ErrorMessage = "Minimum 2 characters.", MinimumLength = 2)]

        public string Device { get; set; }

        [Required]
        [DisplayName("Purchase date")]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [DisplayName("Expires date")]
        public DateTime ExpiresDate { get; set; }
    }
}