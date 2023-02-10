using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spices.Models
{
    public class OrderHeader   //  lecture9   00:03:00
    {
        [Key]
        public int iD { get; set; }   
        [Required]
        public String UseriD   { get; set; }
        [ForeignKey("UseriD")]
        public virtual ApplicationUser applicationUser { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public double OrderTotalOrginal { get; set; } // السعر الاصلى للايتم قبل الخصم فى حال استخدام الكوبون
        [Required] 
        [DisplayFormat(DataFormatString ="{0:c}")]
        public double OrderTotal { get; set; }
        [Required]
        [Display(Name = "Pickup Time")]
        public DateTime PickUpTime { get; set; }  // وقت اخذ الطلب
        [Required]
        [NotMapped]
        public DateTime PickUpDate { get; set; }   //    لا تضاف الى قاعده البيانات لاستخدامها فى الفيو فقط

        [Display(Name = "Coupon Code")]
        public string Couponcode { get; set; }  // الكوبون المستخدم

        public string CouponcodeDiscount { get; set; }  

        public string Status { get; set; }

        public string PaymentStatus { get; set; }

        public string Comments { get; set; }
        [Display(Name = "Pickup Name")]
        public string PickUpName { get; set; } // الشخص اللى بياخد الطلب
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public string TrasactionId { get; set; }


    }
}
