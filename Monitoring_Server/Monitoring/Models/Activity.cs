using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monitoring.Models
{
    public class Activity
    {
        public int[] HeartRate { get; set; }

        public int[] BatteryLife { get; set; }

        public int[] ActivityLevel { get; set; }
    }
}