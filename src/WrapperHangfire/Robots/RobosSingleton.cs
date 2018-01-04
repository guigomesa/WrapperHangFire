using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using Hangfire;

namespace WrapperHangfire.Robots
{
    public class RobosSingleton : IRegisteredObject
    {
        public static readonly RobosSingleton Instance = new RobosSingleton();
        private readonly object _lockObject = new object();
        private bool _started;

        private BackgroundJobServer _backgroundJobServer;

        public void Start()
        {
            lock (_lockObject)
            {
                if (_started) return;
                _started = true;

                HostingEnvironment.RegisterObject(this);

                Hangfire.GlobalConfiguration.Configuration.UseStorage(
                    new Hangfire.SqlServer.SqlServerStorage("ConnectioString"));
                _backgroundJobServer = new BackgroundJobServer();
            }
        }

        public void Stop(bool immediate)
        {
            lock (_lockObject)
            {
                if (_backgroundJobServer != null)
                {
                    _backgroundJobServer.SendStop();
                    _backgroundJobServer.Dispose();
                }
                HostingEnvironment.UnregisterObject(this);
            }
        }
        void IRegisteredObject.Stop(bool immediate)
        {
            Stop(immediate);
        }
    }
}