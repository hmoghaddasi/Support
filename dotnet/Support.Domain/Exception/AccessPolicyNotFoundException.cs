using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class AccessPolicyNotFoundException : BusinessException
    {
        public AccessPolicyNotFoundException()
            : base(ExceptionCode.AccessPolicyNotFoundCode, "دسترسی مورد نظر وجود ندارد" + " (" + ExceptionCode.AccessPolicyNotFoundCode.ToString() + ")")
        {
        }
    }
}
