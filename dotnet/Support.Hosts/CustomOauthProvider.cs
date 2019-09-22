using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace Support.Hosts
{
    internal class CustomOauthProvider : OAuthAuthorizationServerProvider
    {
        //private UserService userService;

        //public ApplicationOAuthProvider()
        //{
        //    userService = new UserService();
        //}
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            //return base.ValidateClientAuthentication(context);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == "admin" && context.Password == "123456")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("UserName", "admin"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid grant", "incorrect UserName and Password");
                return;
            }
            //if (context.UserName == "admin" && context.Password == "123456")
            //{
            //var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier,"100"));
            //identity.AddClaim(new Claim(ClaimTypes.Role,"Admin"));
            //identity.AddClaim(new Claim(ClaimTypes.Name, "Administrator"));
            //context.Validated(identity);
            //return base.GrantResourceOwnerCredentials(context);
            //}
            //else
            //{
            //    context.Rejected();
            //    return base.GrantResourceOwnerCredentials(context);
            //}

            //var user = userService.GetUser(context.UserName, context.Password);

            //var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            //oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            //var ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());
            //context.Validated(ticket);
        }
    }
}