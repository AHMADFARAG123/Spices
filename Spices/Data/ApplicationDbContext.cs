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
        public DbSet <SubCategory> SubCategories { get; set; }   //lecture3 5minuts

        public DbSet <MenItem> MenuItems { get; set; }    //lecture4 8:50minuts

        public DbSet<Coupon> Coupons { get; set; }    //lecture5 5:50minuts

    }
}
