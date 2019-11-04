using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class DuplicateProductCodeException : BusinessException
    {
        public DuplicateProductCodeException()
            : base(Framework.Core.Exception.ExceptionCode.PersonIsNotActiveCode, "کد محصول نمی تواند تکراری باشد " + " ("+ Framework.Core.Exception.ExceptionCode.PersonIsNotActiveCode.ToString() + ")")
        {
        }
    }
}
