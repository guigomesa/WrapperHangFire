using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangfire;
using WrapperHangfire.Robots.Brain;

namespace WrapperHangfire.Robots
{
    public abstract class BasicRobot : IDisposable, IRobots
    {
        protected static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string NameRobot { get; protected set; }
        
        protected DateTime LastRun { get; set; }
        protected IBrainRobot Brain { get; set; }
        
        protected BasicRobot(IBrainRobot brain, string nameRobot)
        {
            NameRobot = nameRobot;
            LastRun = DateTime.Now;
            Brain = brain;
        }

        public void Dispose()
        {
        }


        [DisableConcurrentExecution(1200)]
        [AutomaticRetry(OnAttemptsExceeded = AttemptsExceededAction.Delete, Attempts = 4)]
        public virtual void Run()
        {
            RebootRobot();
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                var nameTaks = Brain?.GetType()?.ToString() ?? "Brains is null";
                Log.Error($"Is not possible run task ({nameTaks})", ex);
            }

        }

        protected void InitializeRobot()
        {
            try
            {
                Brain.Reboot();
                LastRun = DateTime.Now.AddMinutes(15);
            }
            catch (Exception ex)
            {
                Log.Error($"Is not possible reboot processor {NameRobot}", ex);
                Log.Debug($"Is not possible reboot processor {NameRobot}", ex);
            }
        }

        protected void RebootRobot()
        {
            if (LastRun >= DateTime.Now)
            {
                InitializeRobot();
            }
        }

        protected bool AnotherInstanceIsRun()
        {
            throw new NotSupportedException();
            //using (var connection = JobStorage.Current.GetConnection())
            //{
            //    string lastRun = string.Empty;
            //    var recurringJobs = connection.GetRecurringJobs();
            //    //var job = recurringJobs.FirstOrDefault(p=> p.Id)
            //}
            //return true;
        }
    }
}