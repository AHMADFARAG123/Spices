using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spices.Data;
using Spices.Models;
using Spices.Models.ViewModels;
using Spices.Utilit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Spices.Areas.Customer.Controllers
{
    [Area("Customer")] // lecture9   30:39
    [Authorize]
    public class CartsController : Controller  //lecture9 00:19:00
    {
        private readonly ApplicationDbContext db;     // lecture9   minuts

        public CartsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]   //اتربيوت بيند بروبرتى  lecture 9  20:00
        public OrderDetailsCartViewModel OrderDetailsCartVM { get; set; }




        public IActionResult Index()
        {          
            
                OrderDetailsCartVM = new OrderDetailsCartViewModel()   //initialize  lecture 9   21:20
                {
                    orderHeader = new Models.OrderHeader()  //set for some property    lecture 9   21:20 

                };

            OrderDetailsCartVM.orderHeader.OrderTotal = 0;                       //lecture9 22:25

            var ClimeSIdentity = (ClaimsIdentity)User.Identity;  //lecture8 1:12:00وصار عندى اوبجيكت من نوع كليمز اي دن تيتى  //من خلال الكليمز اى دى اقدر اجيب اليوزر الحالى اللى عامل لوج ان
            var ClaimM = ClimeSIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var shoppingcArts = db.ShoppingCarts.Where(c =>c.ApplicationUsErId == ClaimM.Value);  //lecture9 25:00  take care==>>     ApplicationUseR.Id    علشان ارجع الايتم اللى موجوده فى الشوبينج كارت
            if (shoppingcArts !=null)  // not equal null 
            {
                  
                OrderDetailsCartVM.ShoppingCarTSlist = shoppingcArts.ToList();   //lecture9 25:56    we make her asign for property number2

            }
            foreach (var iteM in OrderDetailsCartVM.ShoppingCarTSlist)
            {

                iteM.MenIteM = db.MenuItems.FirstOrDefault(m => m.ID == iteM.MenuIteMId);  //lecture9   27:45   FirstOrDefault== where     & we make her asign for property MenIteM
                OrderDetailsCartVM.orderHeader.OrderTotal += iteM.MenIteM.Price * iteM.CouNt ;

                iteM.MenIteM.description = SD.ConvertToRawHtml(iteM.MenIteM.description);   //lecture9   44:19
              
               /* if(iteM.MenIteM.description.Length>75)
                {
                    iteM.MenIteM.description = iteM.MenIteM.description.Substring(0, 70);   //lecture9   46:19

                }*/
            
            
            }

            OrderDetailsCartVM.orderHeader.OrderTotalOrginal = OrderDetailsCartVM.orderHeader.OrderTotal;
            return View(OrderDetailsCartVM);   //lecture9 30:00   
        }
    }
}
