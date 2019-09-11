using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;

namespace Support.Host.Controller
{
    public class UserManagementTools
    {
        public static int GetCurrentPersonId()
        {
            var identity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            return int.Parse(identity?.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException());

        }

        public static string GetCurrentPersonUser()
        {
            var identity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            return identity?.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Name)?.Value;
        }
    }
}