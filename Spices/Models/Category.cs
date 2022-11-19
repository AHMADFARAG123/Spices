using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spices.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }


        [Required]
        [Display(Name="category name")]
        public string Name { get; set; }
    }
}
