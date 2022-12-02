using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spices.Data;
using Spices.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            IndexViewModel IndexVM = new IndexViewModel()
            {
                CategorieS = await db.Categories.ToListAsync(),
                MenItemS = await db.MenuItems.Include(m=>m.CATEGOry).Include(m=>m.SUBcategory).ToListAsync(),
                CouponS = await db.Coupons.Where(m=>m.IsActive).ToListAsync()

            };



            return View(IndexVM);
        }
    }
}
