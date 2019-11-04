using System.Web.Http;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;

namespace Support.Hosts.Controllers
{
    public class ResetPasswordController : ApiController
    {
        private readonly IAuthorizationService _authorizationService;
        public ResetPasswordController(IAuthorizationService authorizationService)
        {
            this._authorizationService = authorizationService;
        }

        [AllowAnonymous]
        [HttpPost]
        public void Post(ResetPasswordDTO req)
        {
            _authorizationService.ResendVerificationCode(req.Mobile);
        }
    }
}