using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spices.Data;
using Microsoft.EntityFrameworkCore;
using Spices.Models.ViewModels;
using Spices.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Spices.Utilit;

namespace Spices.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.manageruser)]  //  lecture7  52:31    وده معناه ان اليوزر كونترولر ده مصرح فقط للرول اللى هو مانجر
    [Area("Admin")]    //lecture4         15:46
    public class MenuItemsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment webHostEnvironmenT;     //webHostEnvironmenT  Lectere4 49:36 كل ده علشان رفع الصور فى المشروع

        [BindProperty]   //اتربيوت بيند بروبرتى  lecture 4  26:00
        public MenuItemViewModel MenuitemVM { get; set; }   //بروبرتى من النوع مينيو ايتم فيو موديل هتكون بيند بروبرتى  lecture4  27:00

        public MenuItemsController(ApplicationDbContext db,IWebHostEnvironment webHostEnvironmenT)  //lacture 4 16:13------- webHostEnvironmenT  Lectere4 49:36   كل ده علشان رفع الصور فى المشروع 
        {
            this.db = db;
            this.webHostEnvironmenT = webHostEnvironmenT;     //- webHostEnvironmenT  Lectere4 49:36   كل ده علشان رفع الصور فى المشروع
            MenuitemVM = new MenuItemViewModel() //lacture 4         27:42
            {
                MeNUitem =new Models.MenItem(),      //فى المحاضره الرابعه هو عملها نيو مينيو ايتم على طول 
                categorieslisT = db.Categories.ToList(),
              //  suBcategorieslisT = db.SubCategories.ToList()         //lacture 4        28:42
        };
        }

        private MenItem MenItem()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task <IActionResult> Index()    //lacture 4         17:13  CATEGOry   SUBcategory
        {
            var meNeuitems =await db.MenuItems.Include(m => m.CATEGOry).Include(m => m.SUBcategory).ToListAsync();   //lacture 4         18:13
            return View(meNeuitems);
        }

        ////////////START Create///////
        //lecture4  28:00     
        [HttpGet]
        public IActionResult Create()    
        {

            return View(MenuitemVM);
        }


        //lecture4  51:00
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task <IActionResult> CreateposT()        //lecture4  51:00    كل ده علشان رفع الصور فى المشروع
        {
            if(ModelState.IsValid)              //lecture4  51:00
            {

               
                string imagPaHT = @"\images\food-dish.png";
                var filEs = HttpContext.Request.Form.Files;  //لما اعمل سممت للفورم هترجع لى ب فايل او بدون فايل
                   if(filEs.Count > 0)  //دى معناها هل فى ملف اتحمل معايا 
                {
                    string webRootPatH = webHostEnvironmenT.WebRootPath;  //lecture4  52:00    كل ده علشان رفع الصور فى المشروع
                    string imageNamE = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(filEs[0].FileName);//هسمى الصورةباسم الجديد
                    FileStream fileStreaM = new FileStream(Path.Combine(webRootPatH, "images", imageNamE), FileMode.Create); //هعرف اوبجيكت من فايل استريم  وهامرر له سترينج باث فى الكونستركتر بتاعه lecture4   56:57
                    filEs[0].CopyTo(fileStreaM);   //lecture4  1:03:00
                    imagPaHT = @"\images\" + imageNamE;
                }

                MenuitemVM.MeNUitem.image = imagPaHT;   //lecture4  1:04:00
                db.MenuItems.Add(MenuitemVM.MeNUitem);
                 await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(MenuitemVM);              //lecture4  51:00
        } ////////////End Create///////


        //////////Start//Edit///////////////lecture 4 1:15:00

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var MenuiteM = db.MenuItems.Include(m => m.CATEGOry).Include(m => m.SUBcategory).SingleOrDefault(m => m.ID == id);
            if (MenuiteM == null)
            {
                return NotFound();  // lecture4   1:17:02 minuts
            }
            MenuitemVM.MeNUitem = MenuiteM;
            MenuitemVM.suBcategorieslisT = await db.SubCategories.Where(m => m.CategoryId == MenuitemVM.MeNUitem.CATEgoryid).ToListAsync();

            return View(MenuitemVM);  // lecture4   1:19:02 minuts

        }

        //lecture4  1:30:00
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> Editpost()        //lecture4  
        {
            if (ModelState.IsValid)              //lecture4  
            {


                // string imagPaHT = MenuitemVM.MeNUitem.image;    //lecture4  1:32:00  ///*******//
                var filEs = HttpContext.Request.Form.Files;  //لما اعمل سممت للفورم هترجع لى ب فايل او بدون فايل
                if (filEs.Count > 0)  //دى معناها هل فى ملف اتحمل معايا 
                {
                    string webRootPatH = webHostEnvironmenT.WebRootPath;  //lecture4     كل ده علشان رفع الصور فى المشروع
                    string imageNamE = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(filEs[0].FileName);//هسمى الصورةباسم الجديد
                    FileStream fileStreaM = new FileStream(Path.Combine(webRootPatH, "images", imageNamE), FileMode.Create); //هعرف اوبجيكت من فايل استريم  وهامرر له سترينج باث فى الكونستركتر بتاعه lecture4  
                    filEs[0].CopyTo(fileStreaM);   //lecture4  
                    string imagPaHT = @"\images\" + imageNamE;  //lecture4  1:33:00  ///*******//
                    MenuitemVM.MeNUitem.image = imagPaHT;   //lecture4  1:32:00  ///*******//
                }

                  
                db.MenuItems.Update(MenuitemVM.MeNUitem);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(MenuitemVM);              //lecture4  

        }    //////////End//Edite///////////////lecture 4 1:30:00



        //////////Start//Details///////////////lecture 4 1:34:00

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var MenuiteM = db.MenuItems.Include(m => m.CATEGOry).Include(m => m.SUBcategory).SingleOrDefault(m => m.ID == id);
            if (MenuiteM == null)
            {
                return NotFound();  // lecture4   1:17:02 minuts
            }
            MenuitemVM.MeNUitem = MenuiteM;
            MenuitemVM.suBcategorieslisT = await db.SubCategories.Where(m => m.CategoryId == MenuitemVM.MeNUitem.CATEgoryid).ToListAsync();

            return View(MenuitemVM);  // lecture4   1:19:02 minuts

        }   //////////End//Details///////////////lecture 4 1:34:00




        //////////Start//Delete///////////////lecture 4 1:15:00

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var MenuiteM = db.MenuItems.Include(m => m.CATEGOry).Include(m => m.SUBcategory).SingleOrDefault(m => m.ID == id);
            if (MenuiteM == null)
            {
                return NotFound();  // lecture4   1:17:02 minuts
            }
            MenuitemVM.MeNUitem = MenuiteM;
            MenuitemVM.suBcategorieslisT = await db.SubCategories.Where(m => m.CategoryId == MenuitemVM.MeNUitem.CATEgoryid).ToListAsync();

            return View(MenuitemVM);  // lecture4   1:19:02 minuts

        }

        //lecture4  1:40:00
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> Deletepost()        //lecture4  
        {
            /*
                
                var filEs = HttpContext.Request.Form.Files;  
                if (filEs.Count > 0)  
                {
                    string webRootPatH = webHostEnvironmenT.WebRootPath;  
                    FileStream fileStreaM = new FileStream(Path.Combine(webRootPatH, "images", imageNamE), FileMode.Create); //هعرف اوبجيكت من فايل استريم  وهامرر له سترينج باث فى الكونستركتر بتاعه lecture4  
                    filEs[0].CopyTo(fileStreaM);   //lecture4  
                    string imagPaHT = @"\images\" + imageNamE;  
                 MenuitemVM.MeNUitem.image = imagPaHT;  
              }
                */

                db.MenuItems.Remove(MenuitemVM.MeNUitem);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));



        }  
        //////////End//Delete///////////////lecture 4 1:30:00



    }


}
