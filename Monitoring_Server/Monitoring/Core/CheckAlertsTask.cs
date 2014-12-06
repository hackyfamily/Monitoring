using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Core
{
    public class CheckAlertsTask: FluentScheduler.ITask
    {
        public void Execute()
        {
            using (var dc = new MonitoringDataContext())
            {
                var fakeData = dc.FakeDatas.Where(x => x.EventDt != null && x.EventDt.Value.Date >= DateTime.Today && x.AlertSent == null).OrderBy(x => x.EventDt).ToArray();

                foreach (var data in fakeData)
                {
                    if (data.Metric == "Heart Rate" && data.Value > 100)
                    {
                        // heart attack?
                        // send email...
                    }
                }
            }
        }
    }
}
