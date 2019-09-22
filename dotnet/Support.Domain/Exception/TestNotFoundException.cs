using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class TestNotFoundException : BusinessException
    {
        public TestNotFoundException() :
            base(Framework.Core.Exception.ExceptionCode.TestNotFoundCode,
                "تستی با این مشخصات در سیستم موجود نیست.")
        {

        }
    }
}
