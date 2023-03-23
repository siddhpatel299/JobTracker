using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Repositories;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {        
        public string emm = string.Empty;

        
        [HttpPost]
        [Route("sendemail")]

        public IActionResult SendEmail(string emailid, string body)
        {
            emm = emailid;
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("apitestmail20@gmail.com"));
            email.To.Add(MailboxAddress.Parse(emailid));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html) { Text = "Hello, "+emailid+"<br>Here is your Secure Hash : "+body+"<br>If previous does not reload automatically follow this link : "+"http://localhost:5158/User/forget"+"<br><br>Thank You,<br>Team Casepoint" };
            using var smtp = new SmtpClient();

            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("apitestmail20@gmail.com", "xnvlqulynkntevai");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();
        }

        UserRepository ur = new UserRepository();
        [HttpPost]
        [Route("forgetpassword")]
        
        public IActionResult ForgetPassword(string email, string pass)
        {
            bool reply = ur.forget(email, pass);
            return Ok(reply);
        }

    }
}