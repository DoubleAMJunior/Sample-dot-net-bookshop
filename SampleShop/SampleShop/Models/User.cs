using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleShop.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Password")]
        public string pass { get; set; }
        [Required]
        public String Address { get; set; }

        public bool Manager { get; set; }   

        public String CartItemIds { get; set; }
    }
}
