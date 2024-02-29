using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataManager.Entities
{
    public class User : IEquatable<User>
    {
        

        [Key]
        public string  email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string BirthDate { get; set; }

        public ICollection<Address> addresses { get; set; }

        public bool Equals([AllowNull] User other)
        {
            return this.email.Equals(other.email);
        }

        public override int GetHashCode()
        {
            return email.GetHashCode();
        }
    }
}
