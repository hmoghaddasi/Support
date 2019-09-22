using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;

namespace Support.Hosts.Controllers
{
    public class UserManagementTools
    {
        public static int GetCurrentPersonId()
        {
            var identity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;

            var claim = identity?.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value ?? "";

            if (string.IsNullOrEmpty(claim))
                throw new InvalidOperationException();

            return int.Parse(claim);

        }

        public static string GetCurrentPersonUser()
        {
            var identity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            return identity?.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Name)?.Value;
        }


    }
}