using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spices.Models
{
    public class Coupon
    {

        //lecture5 2minuts
        [Key]
        public int iD { get; set; }



        [Required]
        [Display(Name = "Name of Coupon")]
        public string Name { get; set; }



        [Required]
        [Display(Name = "Coupon Type")]
        public string CouponType { get; set; }
        public enum EcouponType { percent = 0, Doller= 1 }

         

        [Required]
        public double Discount { get; set; }



        [Required]
        [Display(Name = "Mininmum Amount")]
        public double MininmumAmount { get; set; }


        public byte[]  Picture { get; set; }   //  هنخزن الصوره فى قاعده البيانات نفسها وليس فى الدبليو رووت



        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

    }
}
