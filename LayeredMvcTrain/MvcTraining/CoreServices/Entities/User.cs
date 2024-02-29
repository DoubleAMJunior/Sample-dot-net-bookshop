using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class User
    {
        
        public string  Email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string BirthDate { get; set; }

        public ICollection<Address> addresses { get; set; }
    }
}
