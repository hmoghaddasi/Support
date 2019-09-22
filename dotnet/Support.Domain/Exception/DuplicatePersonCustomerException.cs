using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class DuplicatePersonCustomerException : BusinessException
    {
        public DuplicatePersonCustomerException()
            : base(Framework.Core.Exception.ExceptionCode.DuplicatePersonCustomerCode,
                  "این مشتری قبلا به این فرد تخصیص یافته است " + " (" +
                  Framework.Core.Exception.ExceptionCode.DuplicatePersonCustomerCode + ")")
        {
        }
    }
}


