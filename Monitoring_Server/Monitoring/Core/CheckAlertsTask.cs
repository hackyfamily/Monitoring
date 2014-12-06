using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Monitoring.Core
{
    public class CheckAlertsTask: FluentScheduler.ITask
    {
        private string phone = WebConfigurationManager.AppSettings["Phone"];

        public void Execute()
        {
            
            using (var dc = new MonitoringDataContext())
            {
                var fakeData = dc.FakeDatas.Where(x => x.EventDt != null && x.EventDt.Value.Date >= DateTime.Today && x.AlertSent == null).OrderBy(x => x.EventDt).ToArray();

               foreach (var data in fakeData)
                {
                    if (data.Metric == "Heart Rate" && data.Value > 100)
                    {
                        // Send Alert - Heart Attack 
                        SendSMS(phone, "Heart Rate", "Alert: Heart Rate > 100");
                        data.AlertSent = true;
                    }
                    else
                    {
                        data.AlertSent = false;
                    }
                }
                dc.SubmitChanges();
            }
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
