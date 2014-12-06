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
        public ActionResult Index()
        {
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

        public ActionResult TriggerAlert()
        {
          // Send Alert - Heart Attack 
            string recipient = WebConfigurationManager.AppSettings["Phone"];
            string eventName = "Heart Rate";
            string body = "Alert: Heart Rate > 100. Emergency Services Contact Number: 615.945.6528";

            
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

            return RedirectToAction("Index", "Home");
        }

    }
}
