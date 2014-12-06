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
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
