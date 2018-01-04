using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangfire.Dashboard;

namespace WrapperHangfire.Filters
{
    public class MyRestrictiveAuthorizationHangfireFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var cookie = HttpContext.Current.Request.Cookies["cookieHangfire"];
            return cookie != null && cookie.Value.Equals("abc123");
        }
    }
}