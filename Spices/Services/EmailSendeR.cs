using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spices.Services
{
    public class EmailSendeR : IEmailSender  //Lecture7  35:00   هيعمل انهيريتانس من انتر فيس اسمها اى ايميل سيندر

    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
