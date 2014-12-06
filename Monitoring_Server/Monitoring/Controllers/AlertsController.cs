using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Monitoring.Controllers
{
    public class AlertsController : Controller
    {
        //
        // GET: /Alerts/

        public ActionResult Index()
        {
            return View();

            /*
            //string recipient = "2146862632@txt.att.net";  //Aaron's cellphone
            string recipient = "aarauz15@gmail.com";
            string eventName = "Heart Stop";
            string body = "Test message, please ignore";

            SendSMS(recipient, eventName, body);
            */
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            return RedirectToAction("Index", "Home");
        }

        private void SendSMS(string recipient, string eventName, string body)
        {
            string server = WebConfigurationManager.AppSettings["SMTPServer"];
            int port = Int32.Parse(WebConfigurationManager.AppSettings["SMTPPort"]);
            string username = WebConfigurationManager.AppSettings["SMTPUser"];
            string password = WebConfigurationManager.AppSettings["SMTPPassword"];

            SmtpClient client = new SmtpClient(server, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };

            MailMessage mailMessage = new MailMessage(username, recipient);
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = string.Format("Alert for {0}", eventName);
            mailMessage.Body = body;

            client.Send(mailMessage);
        }

    }
}
