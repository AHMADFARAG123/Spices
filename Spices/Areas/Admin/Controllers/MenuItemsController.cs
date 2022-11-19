using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spices.Data;
using Microsoft.EntityFrameworkCore;

namespace Spices.Areas.Admin.Controllers
{
    [Area("Admin")]    //l 4         15:46
    public class MenuItemsController : Controller
    {
        private readonly ApplicationDbContext db;

        public MenuItemsController(ApplicationDbContext db)  //lacture 4         16:13
        {
            this.db = db;
        }

        [HttpGet]
        public async Task <IActionResult> Index()    //lacture 4         17:13  CATEGOry   SUBcategory
        {
            var meNeuitems =await db.MenuItems.Include(m => m.CATEGOry).Include(m => m.SUBcategory).ToListAsync();   //lacture 4         18:13
            return View(meNeuitems);
        }
    }
}
