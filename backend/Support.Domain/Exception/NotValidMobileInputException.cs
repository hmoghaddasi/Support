using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class NotValidMobileInputException : BusinessException
    {
        public NotValidMobileInputException()
            : base(ExceptionCode.AccessPolicyNotFoundCode, "شماره موبایل وارد شده صحیح نمی باشد")
        {
        }
    }
}
