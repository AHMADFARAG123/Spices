using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spices.Models
{
    public class ShoppingCart
    {

        public ShoppingCart()    //lecture8  12:29:00  هعمل كونستراكتر
        {
            CouNt = 1;
        }

        [Key]
        public int id { get; set; }  //lecture8  02:00:00

        public string ApplicationUsErId { get; set; }
        [NotMapped]
        [ForeignKey("ApplicationUsErId")]   //D=> Uper Case  
        public virtual ApplicationUser ApplicationUseR { get; set; }
        public int MenuIteMId { get; set; }
         [NotMapped]
        [ForeignKey("MenuIteMId")]
        public virtual MenItem MenIteM { get; set; }
       
        [Range(1, int.MaxValue, ErrorMessage = "Please Enter Value grater than O r equal 1")]

         public int CouNt { get; set; }

    }
}
