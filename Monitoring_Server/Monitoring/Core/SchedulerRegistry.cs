using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentScheduler.Model;
using FluentScheduler.Extensions;

namespace Monitoring.Core
{
    public class SchedulerRegistry: FluentScheduler.Registry
    {

        public SchedulerRegistry()
        {
            this.Schedule<CheckAlertsTask>().ToRunEvery(10).Seconds();
        }
    }
}
