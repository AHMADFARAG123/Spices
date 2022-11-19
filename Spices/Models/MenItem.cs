using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spices.Models
{
    public class MenItem
    {

        [Key]
        public int ID { get; set; }  //1

        [Required]
        [Display(Name = "Name MEnuItem")]
        public string Name { get; set; }   //2

      //  [Required]
        public string description { get; set; }   //3
      //  [Required]
        public double Price { get; set; }    //4
       
        public string image { get; set; }   //5

              //
        public string Spicnyness { get; set; }
        public enum EspiCy {NA=0,NotSpicy=1,Spicy=2,VerySpicy=3}

             //
                       //--/
        // [Required]
        [Display(Name="Name CategOry")]
        public int CATEgoryid { get; set; }
        [ForeignKey("CATEgoryid")]   //  atrebute    l4     6:25
        public Category CATEGOry { get; set; }     //بروبرتى عبارة عن كاتيجورى ابجكت  6:40   l4
                      //--/

        // [Required]
        [Display(Name = "Name SubCategOry")]
        public int SubCategOryid { get; set; }
        [ForeignKey("SubCategOryid")]
        public SubCategory SUBcategory { get; set; }




        






    }
}
