using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Core.Entities
{
    public class Address
    {
        public Address()
        {

        }
        public Address(string s)
        {
            address = s;
        }

        public int id { get; set; }
        public string address { get; set; }

    }
}
