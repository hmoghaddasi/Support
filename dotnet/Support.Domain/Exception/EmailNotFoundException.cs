using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class EmailNotFoundException : BusinessException
    {
        public EmailNotFoundException() :
            base(Framework.Core.Exception.ExceptionCode.EmailNotFoundCode,
                "ایمیلی با این مشخصات در سیستم موجود نیست.")
        {

        }
    }
}
