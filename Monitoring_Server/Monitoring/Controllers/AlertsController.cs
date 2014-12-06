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
    }
}
