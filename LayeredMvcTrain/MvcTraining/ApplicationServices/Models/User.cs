using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApplicationServices.Models
{
    public class User
    {
        [Key]
        public string email { get; set; }

        [Required(ErrorMessage ="where is name?")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "where is lastname?")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "where is bd?")]
        [RegularExpression(@"^\d{4}/\d{1,2}/\d{1,2}")]
        public string BirthDate { get; set; }

        public string address1 { get; set; }
        public string address2 { get; set; }
    }
}
