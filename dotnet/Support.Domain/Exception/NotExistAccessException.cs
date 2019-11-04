using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class NotExistAccessException : BusinessException
    {
        public NotExistAccessException()
            : base(ExceptionCode.AccessNotFoundCode, "This Access does not Exist" + " (" + ExceptionCode.AccessNotFoundCode.ToString() + ")")
        {
        }
    }
}
