using Microsoft.AspNetCore.Authorization;  //lecture7  52:29
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;   //lecture7  46:42
using Spices.Data;
using Spices.Utilit;  //lecture7  53:07
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;  //lecture7  46:30
using System.Threading.Tasks;

namespace Spices.Areas.Admin.Controllers
{
    [Authorize(Roles =SD.manageruser)]  //  lecture7  52:31    وده معناه ان اليوزر كونترولر ده مصرح فقط للرول اللى هو مانجر 
    [Area("Admin")]
    public class UsersController : Controller    // lecture7   41:00
    {
        private readonly ApplicationDbContext db;

        public UsersController(ApplicationDbContext db)    //          هنعرف الكونستراكتر لهذا الكونترولر وهنعمل انجيكت للابليكيشن دى بى كونتيكست
        {
            this.db = db;   //initialize
        }



        public async Task<IActionResult> Index()  //lecture7  43:00
        {
            var ClimeSIdentity = (ClaimsIdentity)User.Identity;  //وصار عندى اوبجيكت من نوع كليمز اي دن تيتى  //من خلال الكليمز اى دى اقدر اجيب اليوزر الحالى اللى عامل لوج ان
            var ClaimM = ClimeSIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string UserID = ClaimM.Value;
            return View(await db.ApplicationUsers.Where(m => m.Id != UserID).ToListAsync());



        }

        public async Task<IActionResult> LockUNlock(string? iD)  //lecture7  01:29:40
        {
            if(iD==null)
            {
                return NotFound();
            }
            var usEr = await db.ApplicationUsers.FindAsync(iD);   ////lecture7  01:30:27

            if (usEr==null)
            {
                return NotFound();
            }

            if(usEr.LockoutEnd==null ||usEr.LockoutEnd<DateTime.Now)   //lecture7  01:31:27     هفحص لو 
            {

                usEr.LockoutEnd = DateTime.Now.AddYears(1000);   //  اغلق حسابه

            }
            else 
            {
                usEr.LockoutEnd = DateTime.Now;                //افتح حسابه     lecture7  01:33:00   
            }
           
                await db.SaveChangesAsync();                      //علشان يعمل اب ديت لهذه البروبرتى فى جدول  الايه اس بى يوزرز    

                return RedirectToAction(nameof(Index));     //lecture7  01:34:03

        }

    }
}
 //   \  | 