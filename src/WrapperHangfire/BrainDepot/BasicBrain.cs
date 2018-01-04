using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WrapperHangfire.Robots.Brain;

namespace WrapperHangfire.BrainDepot
{
    public class BasicBrain : IBrainRobot
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Process()
        {
            throw new NotImplementedException();
        }

        public void Reboot()
        {
            throw new NotImplementedException();
        }
    }
}