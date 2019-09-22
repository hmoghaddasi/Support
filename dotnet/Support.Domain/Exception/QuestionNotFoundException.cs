using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class QuestionNotFoundException : BusinessException
    {
        public QuestionNotFoundException() :
            base(Framework.Core.Exception.ExceptionCode.QuestionNotFoundCode,
                "سوالی با این مشخصات در سیستم موجود نیست.")
        {

        }
    }
}
