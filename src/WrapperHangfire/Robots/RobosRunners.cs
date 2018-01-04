using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangfire;
using WrapperHangfire.BrainDepot;

namespace WrapperHangfire.Robots
{
    public static class RobosRunners
    {
        public static void RunAllRobots()
        {
            //start all robots here
            RunExampleRobot();
        }

        public static void RunExampleRobot()
        {
            RecurringJob.AddOrUpdate(() => new RobotDepot.ExampleRobot(new BasicBrain(), "BasicRobot").Run(),
                Cron.MinuteInterval(10), TimeZoneInfo.Utc, "critical");
        }
    }
}