using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Monitoring.Controllers
{
    public class LiveController : Controller
    {
        private static List<int> _data = new List<int>{70, 75, 77, 76};

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Data()
        {
            Random random = new Random();

            int y = random.Next(70, 100);

            _data.RemoveAt(0);
            _data.Add(y);

            return Json(_data.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}
