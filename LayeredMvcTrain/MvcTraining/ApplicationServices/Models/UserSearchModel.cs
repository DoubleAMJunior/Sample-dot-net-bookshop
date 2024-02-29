using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApplicationServices.Models
{
    public class UserSearchModel
    {
        [DisplayName ("Name")]
        public string name { get; set; }
        [RegularExpression(@"^\d{4}/\d{1,2}/\d{1,2}", ErrorMessage = "need yyyy/mm/dd")]
        [DisplayName("From date")]
        public string startBD { get; set; }
        [DisplayName("To date")]
        [RegularExpression(@"^\d{4}/\d{1,2}/\d{1,2}",ErrorMessage ="need yyyy/mm/dd")]
        public string endBD { get; set; }
    }
}
