using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spices.Data;
using Spices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Spices.Areas.Admin.Controllers
{
    [Area("Admin")]    // lecture5       7:46
    public class CouponsController : Controller
    {
        private readonly ApplicationDbContext db;     // lecture5  7 minuts

        public CouponsController(ApplicationDbContext db)
        {
            this.db = db;
        }



        //Get
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var copuN = await db.Coupons.ToListAsync();

            return View(copuN);
        }

       ////////////START Create///////
        //Get
        [HttpGet]    // lecture5  12 minuts
        public IActionResult Create()
        {


            return View();
        }


        //post
        [HttpPost]        // lecture5  12 minuts
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Coupon cOupon)
        {


            if (ModelState.IsValid)              //lecture5  18:00
            {
                var filEs = HttpContext.Request.Form.Files;      //لما اعمل سممت للفورم هترجع لى ب فايل او بدون فايل  //  هحط الفايل(الصورة) اللى انا حملتها فى الفار اللى اسمه فايل

                if (filEs.Count > 0)
                {

                    byte[]picturE = null;// اعرف اراى او بايت واسميها بيكتيشر 

                    var fs = filEs[0].OpenReadStream();                   //lecture5      //هعرف اوبجكت من نوع استريم واسمه فاييل استريم(اف اس ) علشان يقرأ الفاييل اللى انا حملته)
                    var ms = new MemoryStream();                 //lecture5  20:00    //هعرف اوبجكت من نوع ميمورى استريم واسميه ام اس)
                    fs.CopyTo(ms);           //بنسخ الفاييل اللى انا حملته على الميمورى استريم

                    picturE = ms.ToArray(); //وبحول الميمورى استريم الى اراى   وبكده انا حولت الصورة اللى رفعناها الى اراى اوف بايت زى البروبرتى بيكتيشر الموجوده فى المودل كوبون
                    cOupon.Picture = picturE; 

                }
               

                db.Coupons.Add(cOupon);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                ////////////End Create///////


            }

            return View(cOupon);  //lrecture5  24:00


       
        }

        ///////////////////Start  edit coupon////////////////////////////////////////////////

        // lecture5   28:05:02 minuts   
        //Get
        [HttpGet]
        public async Task<IActionResult> Edit(int? ID)
        { 
            if (ID == null)
            {
                return NotFound();

            }

            var coupOn = await db.Coupons.FindAsync(ID);
            if (coupOn == null)
            {
                return NotFound();  // lecture5   28:00:00minuts
            }
            

            return View(coupOn);
        }



        //post
        [HttpPost]        // lecture5  12 minuts
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Coupon cOupon)
        {


            if (ModelState.IsValid)              //lecture5  
            {
                var filEs = HttpContext.Request.Form.Files;      
                if (filEs.Count > 0)
                {

                    byte[] picturE = null;
                    var fs = filEs[0].OpenReadStream();                  
                    var ms = new MemoryStream();                 //lecture5  
                    fs.CopyTo(ms);          
                    picturE = ms.ToArray();
                    cOupon.Picture = picturE;

                }
                db.Coupons.Update(cOupon);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                }
            return View(cOupon);  //lrecture5  34:00
       }  /////////////////////////////// End edit coupon//////Get  and Post//////////////////////







        ///////////////////Start  Delete coupon////lecture5///38/////////////////////////////////////////

        // lecture5   38:05:02 minuts   
        //Get
        [HttpGet]
        public async Task<IActionResult> Delete(int? ID)
        {
            if (ID == null)
            {
                return NotFound();

            }

            var coupOn = await db.Coupons.FindAsync(ID);
            if (coupOn == null)
            {
                return NotFound();  // lecture5   00:00:00minuts
            }


            return View(coupOn);
        }



        //post
        [HttpPost]        // lecture5   minuts
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Coupon cOupon)
        {


           
                db.Coupons.Remove(cOupon);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
        }  /////////////////////////////// End delte//////Get  and Post//////////////////////

        ///////////////////Start  details coupon////lecture5///41/////////////////////////////////////////

        // lecture5   41:05:02 minuts   
        //Get
        [HttpGet]
        public async Task<IActionResult> Details(int? ID)
        {
            if (ID == null)
            {
                return NotFound();

            }

            var coupOn = await db.Coupons.FindAsync(ID);
            if (coupOn == null)
            {
                return NotFound();  // lecture5   00:00:00minuts
            }


            return View(coupOn);
            ///////////////////end  details coupon////lecture5///41/////////////////////////////////////////
        }

    }
}
