using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Spices.Models;   //lecture7  19:00
using Spices.Utilit;

namespace Spices.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;  
        private readonly RoleManager<IdentityRole> _roleManager;   //lecture726:54

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> RoleManager  //lecture726:54

            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;  
            _roleManager = RoleManager; //lecture726:54
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }


            [Required]
            public string Name { get; set; }     //lecture7  9:00:00

            [Display(Name = "Street address")]
            public string StreetAddress { get; set; }

            [Display(Name = "postal code")]
            public string postalCode { get; set; }
            public string City { get; set; }
            public string State { get; set; }

            [Display(Name = " Phone Number")]    //lecture7  14:00:00
            public string PhoneNumber { get; set; }
           


        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser   //lecture7  19:00
                { UserName = Input.Email,
                    Email = Input.Email,
                    Name = Input.Name,
                    PhoneNumber = Input.PhoneNumber,
                    StreetAddress = Input.StreetAddress,
                    City = Input.City,
                    State =  Input.State,
                    postalCode = Input.postalCode
                   
                };  //lecture7  18:30



                var result = await _userManager.CreateAsync(user, Input.Password);   //هيعمل كرييت لليوزر 
                if (result.Succeeded)
                {


                    if (! await _roleManager.RoleExistsAsync(SD.manageruser))    //  lecture7  27:54
                    {

                        await _roleManager.CreateAsync(new IdentityRole(SD.manageruser));

                    }




                    if (!await _roleManager.RoleExistsAsync(SD.kitchenuser))    //  lecture7  27:54
                    {

                        await _roleManager.CreateAsync(new IdentityRole(SD.kitchenuser));

                    }




                    if (!await _roleManager.RoleExistsAsync(SD.frontdeskuser))    //  lecture7  27:54
                    {

                        await _roleManager.CreateAsync(new IdentityRole(SD.frontdeskuser));

                    }




                    if (!await _roleManager.RoleExistsAsync(SD.customerenduser))    //  lecture7  27:54
                    {

                        await _roleManager.CreateAsync(new IdentityRole(SD.customerenduser));

                    }



                    string role = HttpContext.Request.Form["RDuserRole"].ToString();  //       lecture7 01:06:50  RDuserRole هل الفورم ارسل لى قيمه اسمها 


                    if(string.IsNullOrEmpty(role))   //هفحص المتغير روول لو كان فاضى يبقى اللى بيعمل الريجستراشن هو كاستمر 
                    {                    
                    
                        
                        await _userManager.AddToRoleAsync(user, SD.customerenduser);     //  lecture7  54:08 

                        await _signInManager.SignInAsync(user, isPersistent: false);  //  lecture7  01:09:02:08
                        return LocalRedirect(returnUrl);   //  lecture7  01:09:02:08
                    }
                    else 
                    {
                        await _userManager.AddToRoleAsync(user, role);   //  lecture7  01:08:
                    }


                    return RedirectToAction("Index", "Users", new { area = "Admin" });////  lecture7  01:10:26  //   وبالتالى اللى قاعد يعمل ريجيستراشن هو المانيجر وبالتالى رجعه على الانديكس والكونترولر اللى اسمها يوزرز والاريا اللى اسمها ادمن



                    // await _userManager.AddToRoleAsync(user, SD.manageruser);     //  lecture7  30:00 


                    /*  lecture7   24:35
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                    */
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
