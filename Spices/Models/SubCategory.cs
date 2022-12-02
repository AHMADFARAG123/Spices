using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spices.Models
{
    public class SubCategory
    {
        //lecture3 2minuts
        [Key]  
        public int id { get; set; }


        [Required]
        [Display(Name = "Sub Category Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "CAtegory")]   // i I mean upr case "CA" categoryId
        public int CategoryId { get; set; }  // i I mean lower case "c" categoryId
        [ForeignKey("CategoryId")] 
        public virtual Category caTegory { get; set; }     // i I mean upr case "T" caTegory
    }
}
