using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class DuplicateOrderNumberException : BusinessException
    {
        public DuplicateOrderNumberException()
            : base(Framework.Core.Exception.ExceptionCode.DuplicateOrderNumber, "شماره سفارش نمی تواند تکراری باشد " + " (" + Framework.Core.Exception.ExceptionCode.DuplicateOrderNumber.ToString() +")")
        {
        }
    }
}
