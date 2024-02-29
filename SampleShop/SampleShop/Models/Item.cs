using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleShop.Models
{
    public class Item 
    {
        [Key]
        public int Id  { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int NumAvailable { get; set; }
        public string picAddress { get; set; }
    }
}
