using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class NotExistAccessPloicyException : BusinessException
    {
        public NotExistAccessPloicyException()
            : base(ExceptionCode.AccessPolicyNotFoundCode, "This AccessPolicy does not Exist" + " (" + ExceptionCode.AccessPolicyNotFoundCode.ToString() + ")")
        {
        }
    }
}
