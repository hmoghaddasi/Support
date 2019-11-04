using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class DuplicateCustomerCodeException : BusinessException
    {
        public DuplicateCustomerCodeException()
            : base(Framework.Core.Exception.ExceptionCode.PersonNotFoundCode, "کد مشتری نمی تواند تکراری باشد " + " (" + Framework.Core.Exception.ExceptionCode.PersonNotFoundCode.ToString() + ")")
        {
        }
    }
}
