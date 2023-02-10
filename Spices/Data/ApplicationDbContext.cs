using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Spices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spices.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet <SubCategory> SubCategories { get; set; }   //lecture3 5minuts   بعرف بروبيرتى من نوع دى بى سيت اوف صب كاتيجورى 

        public DbSet <MenItem> MenuItems { get; set; }    //lecture4 8:50minuts

        public DbSet<Coupon> Coupons { get; set; }    //lecture5 5:50minuts 
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }    //lecture7 5:42minuts
                                                                        
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }    //lecture8 6:00minuts   
        public DbSet<OrderHeader> OrderHeaders { get; set; }    //lecture9 00:15:00   
        public DbSet<OrderDetail> OrderDetails { get; set; }    //lecture9 00:15:00 

    }
}
