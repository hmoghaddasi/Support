using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class ResponseNotFoundException : BusinessException
    {
        public ResponseNotFoundException()
            : base(ExceptionCode.RsponseNotFoundCode, "'گفتگو مورد نظر وجود ندارد " + " (" + ExceptionCode.RsponseNotFoundCode.ToString() + ")")
        {
        }
    }
}
