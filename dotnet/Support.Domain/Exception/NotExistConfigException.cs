using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class NotExistConfigException : BusinessException
    {
        public NotExistConfigException()
            : base(Framework.Core.Exception.ExceptionCode.NotExistConfigCode, "This Config does not Exist" + " (" + Framework.Core.Exception.ExceptionCode.NotExistConfigCode.ToString() + ")")
        {
        }
    }
}
