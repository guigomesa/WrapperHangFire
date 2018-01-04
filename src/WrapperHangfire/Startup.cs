using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangfire;
using Owin;
using WrapperHangfire.Robots;

namespace WrapperHangfire
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var options = new BackgroundJobServerOptions
            {
                Queues = new[] { "critical", "default" },

            };
            
            app.UseHangfireServer(options);
            app.UseHangfireDashboard("/hangfire",

                new DashboardOptions
                {
                    Authorization = new[] { new Filters.MyRestrictiveAuthorizationHangfireFilter() }
                }
            );
            
            RobosRunners.RunAllRobots();
        }
    }
}