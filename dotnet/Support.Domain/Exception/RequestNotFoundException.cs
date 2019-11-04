using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class RequestNotFoundException : BusinessException
    {
        public RequestNotFoundException()
            : base(ExceptionCode.RequestNotFoundCode, "ریکوئست مورد نظر وجود ندارد " + " (" + ExceptionCode.RequestNotFoundCode.ToString() + ")")
        {
        }
    }
}
