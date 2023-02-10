using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spices.Data;
using Spices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
          
            services.AddIdentity<IdentityUser,IdentityRole>(options =>     //lecture7    =>>   32:25   +   30:47   + 01:25:00
            {
                options.SignIn.RequireConfirmedAccount = false;    //  //lecture7    =>>   32:25   +   30:47 false علشان لو اليوزر دخل باسورده اكثر من مره خطأ يتم غلق حسابه
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(6);       //  lecture7  01:26:40  الاوبشن ده علشان لو  اليوزر دخل باسورده اكثر من مره خطأ يتم غلق حسابه لمده 6ساعات
                options.Lockout.MaxFailedAccessAttempts=3;   //lecture7  01:35:00  لما يدخل الباسورد خطأ اكثر من ثلاث مرات يتم غلق حسابه
            }

            )    //lecture7  01:25:00

                .AddDefaultTokenProviders()                                     //lecture7 32:25  33:45 
                .AddDefaultUI()                                                 // lecture7    34:22+    01:13:21   this is the first solving there are another solve
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSingleton<IEmailSender,EmailSendeR>();                  // lecture7 36:30    هعمل ريجستراشن للانتر فيس اى  ايميل سندر وللكلاس ايميل سيندر(اللى عمل امبيلتيشن للاى  ايميل سيندر
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddSession(                  // lecture8  59:00:00

                options =>
                {
                    options.Cookie.IsEssential = true;                            // lecture8  59:00:00
                    options.IdleTimeout = TimeSpan.FromMinutes(30);                    // lecture8  59:00:00  dependence injection container region
                    options.Cookie.HttpOnly = true;                                  // lecture8  59:00:00

                }  
                );                         // lecture8  59:00:00
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseDefaultFiles(); // 
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();     // lecture8    58:15:00  medleware region

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();


                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapRazorPages();
            });
        }
    }
}
