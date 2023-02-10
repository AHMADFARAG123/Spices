using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spices.Data;
using Spices.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spices.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Spices.Utilit;

namespace Spices.Areas.Customer.Controllers
{
    [Area("Customer")]  //lecture6 6:5
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task <IActionResult> Index()    //lecture6 8:5                
        {

            var ClimeSIdentity = (ClaimsIdentity)User.Identity;  //lecture8 1:12:00وصار عندى اوبجيكت من نوع كليمز اي دن تيتى  //من خلال الكليمز اى دى اقدر اجيب اليوزر الحالى اللى عامل لوج ان
            var ClaimM = ClimeSIdentity.FindFirst(ClaimTypes.NameIdentifier);
           
            if (ClaimM != null)
            {
                List<ShoppingCart> SHoppingcarTs = await db.ShoppingCarts.Where(m => m.ApplicationUsErId == ClaimM.Value).ToListAsync();  //lecture8  1:12:00
                HttpContext.Session.SetInt32(SD.shoppingcartcount, SHoppingcarTs.Count);  //lecture8   1:12:00
            }
                         
                                                                                                           
           
           




            IndexViewModel IndexVM = new IndexViewModel()
            {
                CategorieS = await db.Categories.ToListAsync(),
                MenItemS = await db.MenuItems.Include(m=>m.CATEGOry).Include(m=>m.SUBcategory).ToListAsync(),
                CouponS = await db.Coupons.Where(m=>m.IsActive==true).ToListAsync()  // lecture6   20 minuts

            };



            return View(IndexVM);
        }

        [HttpGet]  //lecture8  26:44:00
        [Authorize]   //lecture8  26:44:00
        public async Task <IActionResult> Details(int ID)    // lecture8     08:09:00 or int itemid          بضيف اكشن ريزلت جديده والميثود هيكون اسمها دييتالز وهاتستقبل انتيجر اى دى   
        {
           
            var MEnuitem =await db.MenuItems.Include(m => m.CATEGOry).Include(m => m.SUBcategory).Where(m => m.ID == ID).FirstOrDefaultAsync();   // lecture8     09:58:00

            ShoppingCart ShoppingCarT = new ShoppingCart()  //هعرف اوبجيكت من الشوبينج كارت موديل
            {
                MenIteM = MEnuitem,       // ShoppingCarTالان هعطى قيم للبروبريتى الموجوده داخل الاوبجيكت   lecture8     11:07:00 
                MenuIteMId = MEnuitem.ID
              
            };
            return View(ShoppingCarT);

        }
         
        [HttpPost]    // lecture8 36:33:00
        [ValidateAntiForgeryToken]   // lecture8 36:33:00
        [Authorize]
        public async Task<IActionResult> Details (ShoppingCart shoppingCarT)    // lecture8 36:33:00هاتستقبل موديل من الشوبينج كارت 
        {
            if (ModelState.IsValid)
            {
                
                shoppingCarT.id = 0;  //lecture8   52:58:00
                var ClimeSIdentity = (ClaimsIdentity)User.Identity;  //وصار عندى اوبجيكت من نوع كليمز اي دن تيتى  //من خلال الكليمز اى دى اقدر اجيب اليوزر الحالى اللى عاملوج ان
                var ClaimM = ClimeSIdentity.FindFirst(ClaimTypes.NameIdentifier);
                shoppingCarT.ApplicationUsErId = ClaimM.Value;

                var shopingCartfromDB =await db.ShoppingCarts.Where(m => m.ApplicationUsErId == shoppingCarT.ApplicationUsErId &&  m.MenuIteMId == shoppingCarT.MenuIteMId).FirstOrDefaultAsync(); //42:49:00   lecture8

                if(shopingCartfromDB==null)
                {

                    db.ShoppingCarts.Add(shoppingCarT);

                }
                else
                {

                    shopingCartfromDB.CouNt += shoppingCarT.CouNt;  //LECTURE8  44:00:00 or   shopingCartfromDB.CouNt = shopingCartfromDB.CouNt + shoppingCarT.CouNt;
                    

                }
                await db.SaveChangesAsync(); //lecture8   44:35:00

                var counT = db.ShoppingCarts.Where(m => m.ApplicationUsErId == shoppingCarT.ApplicationUsErId).ToList().Count;  // lecture8  46:33:00  هجيب عدد الايتم الموجوده فى الشوبينج كارت

               HttpContext.Session.SetInt32(SD.shoppingcartcount, counT);


                return RedirectToAction(nameof(Index));   //lecture8  48:29:00 
            }
            else
            {
                var MEnuitem = await db.MenuItems.Include(m => m.CATEGOry).Include(m => m.SUBcategory).Where(m => m.ID == shoppingCarT.MenuIteMId).FirstOrDefaultAsync();   // lecture8     49:25:00

                ShoppingCart ShoppingCarTT = new ShoppingCart()  //هعرف اوبجيكت من الشوبينج كارت موديل
                {
                    MenIteM = MEnuitem,       // ShoppingCarTالان هعطى قيم للبروبريتى الموجوده داخل الاوبجيكت   lecture8     49:25:00 
                    MenuIteMId = MEnuitem.ID

                };
                   return View(ShoppingCarTT);


            }


        }

    }
}
