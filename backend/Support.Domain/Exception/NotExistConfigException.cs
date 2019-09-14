using Framework.Core.Exception;

namespace Pms.Domain.Exception
{
    public class NotExistConfigException : BusinessException
    {
        public NotExistConfigException()
            : base(ExceptionCode.NotExistConfigCode, "This Config does not Exist" + " (" + ExceptionCode.NotExistConfigCode.ToString() + ")")
        {
        }
    }
}
