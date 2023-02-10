using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spices.Data;
using Spices.Models;
using Spices.Utilit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spices.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.manageruser)]  //  lecture7  52:31    وده معناه ان اليوزر كونترولر ده مصرح فقط للرول اللى هو مانجر
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext db;

        public CategoriesController(ApplicationDbContext db)
        {

            this.db = db;
        }

        //Get
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var result = await db.Categories.ToListAsync();

            return View(result);
        }


        [HttpGet]
        public IActionResult Create()      // lecture2   minuts
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Category category)    // lecture2  35 minuts
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);

       }


        [HttpGet]     // lecture2  46 minuts
        public async Task<IActionResult> Edit(int? id)    // lecture2  45 minuts
        {
            if(id==null)
            {
                return NotFound();

            }

            var categ = await db.Categories.FindAsync(id);
            if (categ==null)
            {
                return NotFound();
            }
            return View(categ);
        }

        // lecture2  45 minuts
        [HttpPost] // lecture2  53 minuts      
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                db.Categories.Update(category);
                 await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }
            return View(category);
        }




        [HttpGet]
        public async Task<IActionResult> Delete(int? id)    // lecture2  55 minuts
        {
            if (id == null)
            {
                return NotFound();

            }

            var categ = await db.Categories.FindAsync(id);
            if (categ == null)
            {
                return NotFound();
            }
            return View(categ);
        }




        [HttpPost] // lecture2  59 minuts      
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Category category)
        {
            
                db.Categories.Remove(category);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


        }




        //httpGet  Details method

        [HttpGet]     // lecture2  1:01:35 minuts
        public async Task<IActionResult> Details(int? id)    // lecture2  45 minuts
        {
            if (id == null)
            {
                return NotFound();

            }

            var categ = await db.Categories.FindAsync(id);
            if (categ == null)
            {
                return NotFound();
            }
            return View(categ);
        }
    } 
}