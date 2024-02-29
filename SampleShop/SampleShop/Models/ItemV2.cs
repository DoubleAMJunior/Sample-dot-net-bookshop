using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleShop.Models
{
    public class ItemV2
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int price { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int NumAvailable { get; set; }
        public Byte[] img { get; set; }
    }
}
