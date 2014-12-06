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
            /*
            //string recipient = "2146862632@txt.att.net";  //Aaron's cellphone
            string recipient = "aarauz15@gmail.com";
            string eventName = "Heart Stop";
            string body = "Test message, please ignore";

            SendSMS(recipient, eventName, body);
            */


            using (var dc = new MonitoringDataContext())
            {
                var alerts = dc.Alerts.ToArray();

                return View(alerts);
            }
        }

        [HttpPost]
        public ActionResult Index(Alert[] alerts)
        {
            using (var dc = new MonitoringDataContext())
            {
                foreach (var alert in dc.Alerts)
                {
                    dc.Alerts.DeleteOnSubmit(alert);
                }

                foreach (var alert in alerts)
                {
                    dc.Alerts.InsertOnSubmit(alert);
                }
                dc.SubmitChanges();
            }

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
