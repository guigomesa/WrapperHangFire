using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WrapperHangfire.BrainDepot;
using WrapperHangfire.Robots;
using WrapperHangfire.Robots.Brain;

namespace WrapperHangfire.RobotDepot
{
    public class ExampleRobot : BasicRobot
    {
        protected new static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ExampleRobot() : base(new BasicBrain(), "BasicRobot")
        {
            NameRobot = "BasicRobot";
        }

      
        public ExampleRobot(IBrainRobot brain, string nameRobot) : base(brain, nameRobot)
        {
        }
    }
}