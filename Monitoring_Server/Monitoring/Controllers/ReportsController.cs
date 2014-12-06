using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monitoring.Models;

namespace Monitoring.Controllers
{
    public class ReportsController : Controller
    {
        private static List<int> _data = new List<int> { 70, 75, 77, 76 };

        public ActionResult Index()
        {
            return RedirectToAction("ActivityReport");
        }


        public JsonResult Data()
        {
            Random random = new Random();

            int y = random.Next(70, 100);

            _data.RemoveAt(0);
            _data.Add(y);

            return Json(_data.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ActivityReport()
        {
            if (Request.IsAjaxRequest())
            {
                using (var dc = new MonitoringDataContext())
                {
                    var fakeData = dc.FakeDatas.Where(x => x.EventDt != null && x.EventDt.Value.Date >= DateTime.Today && x.EventDt.Value < DateTime.Now).OrderBy(x => x.EventDt);

                    var heartRate = fakeData.Where(x => x.Metric == "Heart Rate").Take(100).ToArray();
                    var batteryLife = fakeData.Where(x => x.Metric == "Battery Life").Take(100).ToArray();
                    var activityLevel = fakeData.Where(x => x.Metric == "Activity Level").Take(100).ToArray();


                    var result = new
                    {
                        heartRate = heartRate.Select(r => new
                        {
                            x = ToUtc(r.EventDt.GetValueOrDefault().ToUniversalTime()),
                            y = Convert.ToInt32(r.Value)
                        }).ToArray(),
                        batteryLife = batteryLife.Select(r => new
                        {
                            x = ToUtc(r.EventDt.GetValueOrDefault().ToUniversalTime()),
                            y = Convert.ToInt32(r.Value)
                        }).ToArray(),
                        activityLevel = activityLevel.Select(r => new
                        {
                            x = ToUtc(r.EventDt.GetValueOrDefault().ToUniversalTime()),
                            y = Convert.ToInt32(r.Value)
                        }).ToArray()
                    };



                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            return View();
        }

        public ActionResult AlertReport()
        {
            return View();
        }

        public ActionResult LocationLog()
        {
            return View();
        }

        private long ToUtc(DateTime dt)
        {
            return Convert.ToInt64((DateTime.UtcNow - dt.ToUniversalTime()).TotalMilliseconds);
        }
    }
}
