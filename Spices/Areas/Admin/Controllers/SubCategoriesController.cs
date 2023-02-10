using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spices.Data;
using Spices.Models;
using Spices.Models.ViewModels;
using Spices.Utilit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spices.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.manageruser)]  //  lecture7  01:37:55   وده معناه ان اليوزر كونترولر ده مصرح فقط للرول اللى هو مانجر

    [Area("Admin")]
    public class SubCategoriesController : Controller
    {
        private readonly ApplicationDbContext db;    // lecture3   8minuts

        [TempData]      //    دا اسمه اتريبيوت تيمبيرورى تايم lecture3   43minuts
        public string StatusMEssage { get; set; }  //    هعرف بروتيرتى من النوع سترينج واسمها ستيتس ماسيج lecture3   43minuts    ***imean uper E


        public SubCategoriesController(ApplicationDbContext db)
        {
            this.db = db;
        }


        //Get
        [HttpGet]
        public async Task<IActionResult> Index()   // lecture3   8minuts
        {
            var subCategories = await db.SubCategories.Include(m => m.caTegory).ToListAsync();  //بروبرتى اسمها كاتيجورى  (m=>m.caTegory)

            return View(subCategories);
        }


        // lecture3   18minuts
        //Get
        [HttpGet]
        public async Task<IActionResult> Create()   // lecture3   19minuts
        {
            SubCategoryAndCategoryViewModel MoDel = new SubCategoryAndCategoryViewModel()  // i I mean upr case "D" => MoDel
            {

                CategoriesList = await db.Categories.ToListAsync(),
                SubCAtegory = new Models.SubCategory(),
                //لغاها فى الدرس الثالث الدقيقه 53 //  SubCaegoriesList =await db.SubCategories.OrderBy(m=>m.Name).Select(m => m.Name).Distinct().ToListAsync()  // lecture3   20:08minuts

            };

            return View(MoDel);
        }





        // lecture3   34minuts
        //post
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubCategoryAndCategoryViewModel MoDEl)    /* i I mean Upercase "E" MoDEl*/
        {

            if (ModelState.IsValid)    /*lecture3   40minuts*/

            {
                var doesExistSubCategory = await db.SubCategories.Include(m => m.caTegory).Where(m => m.Name == MoDEl.SubCAtegory.Name && m.caTegory.id == MoDEl.SubCAtegory.CategoryId && m.id != MoDEl.SubCAtegory.id).ToListAsync();/*lecture3   40minuts*/    /*كود منع تكرار الصب كاتيجورى*/
                if (doesExistSubCategory.Count() > 0)
                {

                    StatusMEssage = "Error : This Sub Category under" + doesExistSubCategory.FirstOrDefault().caTegory.Name + "Category";     /*lecture3   45:33minuts*/

                }
                else
                {

                    db.SubCategories.Add(MoDEl.SubCAtegory);     /*lecture3   35minuts*/
                    await db.SaveChangesAsync();                          /*lecture3   35minuts*/
                    return RedirectToAction(nameof(Index));

                }

            }


            SubCategoryAndCategoryViewModel MoDelVM = new SubCategoryAndCategoryViewModel()  // lecture3  36:58minuts
            {

                CategoriesList = await db.Categories.ToListAsync(),
                SubCAtegory = MoDEl.SubCAtegory,                               // lecture3  36:58minuts
                                                                               //لغاها فى الدرس الثالث الدقيقه 53 // SubCaegoriesList = await db.SubCategories.OrderBy(m => m.Name).Select(m => m.Name).Distinct().ToListAsync(),
                StatusMessage = StatusMEssage
            };

            return View(MoDelVM);
        }



        [HttpGet]    /*lecture3   49minuts*/
        public async Task<IActionResult> GetSubCATegories(int id)   //هذه الميثود ها تستقبل انتيجر اى دى
        {

            List<SubCategory> subCATegoriEs = new List<SubCategory>(); //  بعرف ليست اوف صب كاتيجورى // هذه الميثود هترجع لى جيسون داتا وانا هقرء هذه الجيسون داتا عن طريق اجاكس
            subCATegoriEs = await db.SubCategories.Where(m => m.caTegory.id == id).ToListAsync();
            return Json(new SelectList(subCATegoriEs, "id", "Name"));   /*lecture3   51:49minuts*/

            // هذه السليكت ليست هحولها الى جيسون

        }

        ///////////////////Start  edit subcategory/////////////////////////////////////////////////////

        // lecture3   1:05:02 minuts   
        //Get
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }

            var subcAteg = await db.SubCategories.FindAsync(id);
            if (subcAteg == null)
            {
                return NotFound();  // lecture3   1:07:02 minuts
            }


            SubCategoryAndCategoryViewModel MoDel = new SubCategoryAndCategoryViewModel()
            {

                CategoriesList = await db.Categories.ToListAsync(),
                SubCAtegory = subcAteg


            };

            return View(MoDel);
        }





        //post
        [HttpPost]    // lecture3   1:08:02 minuts

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubCategoryAndCategoryViewModel MoDEl)
        {

            if (ModelState.IsValid)

            {
                var doesExistSubCategory = await db.SubCategories.Include(m => m.caTegory).Where(m => m.CategoryId == MoDEl.SubCAtegory.CategoryId && m.Name == MoDEl.SubCAtegory.Name && m.id != MoDEl.SubCAtegory.id).ToListAsync();  //وجدتها كده فى المحاضره رقم3 الدقيقة 01:15:01
                                                                                                                                                                                                                                        // var doesExistSubCategory = await db.SubCategories.Include(m => m.caTegory).Where(m => m.Name == MoDEl.SubCAtegory.Name && m.caTegory.id == MoDEl.SubCAtegory.CategoryId && m.id != MoDEl.SubCAtegory.id).ToListAsync();
                if (doesExistSubCategory.Count() > 0)
                {

                    StatusMEssage = "Error : This Sub Category under" + doesExistSubCategory.FirstOrDefault().caTegory.Name + "Category";

                }
                else
                {

                    db.SubCategories.Update(MoDEl.SubCAtegory);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }

            }


            SubCategoryAndCategoryViewModel MoDelVM = new SubCategoryAndCategoryViewModel()
            {

                CategoriesList = await db.Categories.ToListAsync(),
                SubCAtegory = MoDEl.SubCAtegory,

                StatusMessage = StatusMEssage
            };

            return View(MoDelVM);
        }



        /////////////////////////////// End edit subcategory//////Get  and Post//////////////////////



        ///////////////////////////////Start  Delte subcategory////////////////////////////////////////

        // lecture3   1:18:02 minuts   
        //Get
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }

            var subcAtego = db.SubCategories.Include(m => m.caTegory).Where(m => m.id == id).SingleOrDefault();//1:19:02
            if (subcAtego == null)
            {
                return NotFound();  // lecture3   1:07:02 minuts
            }

            return View(subcAtego);
        }



        [HttpPost]   //  01:21:15
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(SubCategory sUbCaTEg)
        {

            db.SubCategories.Remove(sUbCaTEg);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            // lecture3    
        }

        /////////////////////////////End  Delte subcategory/////////////////////////////////////////


        /////////////////////////////Start  Details subcategory///////////////////////////////////////////

        // lecture3   1:23:02 minuts   
        //Get
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }

            var subcAtego = db.SubCategories.Include(m => m.caTegory).Where(m => m.id == id).SingleOrDefault();//1:23:02
            if (subcAtego == null)
            {
                return NotFound();
            }

            return View(subcAtego);
                // lecture3   1:23:02 minuts   End  Details subcategory
       
                
        } 
    }

    }





/* Coment1*/
//Coment2
