using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Monitoring.Controllers
{
    public class SettingsController : Controller
    {

        public ActionResult Index()
        {
            using (var dc = new MonitoringDataContext())
            {
                Setting settings = dc.Settings.FirstOrDefault();

                if (settings == null)
                {
                    settings = new Setting();
                }

                return View(settings);
            }
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
           using (var dc = new MonitoringDataContext())
           {
                Setting settings = dc.Settings.FirstOrDefault();
                if (settings == null)
                {
                    settings = new Setting();
                    dc.Settings.InsertOnSubmit(settings);
                }

                UpdateModel(settings);

                dc.SubmitChanges();
           }

            return RedirectToAction("Index", "Alerts");

        }
    }
}
