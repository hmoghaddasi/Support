using Microsoft.AspNetCore.Mvc;
using Support.Application.Contract.DTO;
using Support.Application.Contract.IService;
namespace Support.Host.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ResetPasswordController: ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        public ResetPasswordController(IAuthorizationService authorizationService)
        {
            this._authorizationService = authorizationService;
        }
        [HttpPost]
        public void Post(ResetPasswordDTO req)
        {
            _authorizationService.ResendVerificationCode(req.Mobile);
        }

    }
}