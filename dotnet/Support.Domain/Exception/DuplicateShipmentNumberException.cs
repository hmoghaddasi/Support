using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class DuplicateShipmentNumberException : BusinessException
    {
        public DuplicateShipmentNumberException()
            : base(Framework.Core.Exception.ExceptionCode.PersonIsNotActiveCode, "شماره محموله نمی تواند تکراری باشد " + " ("+ Framework.Core.Exception.ExceptionCode.DuplicateShipmentNumberCode.ToString() +")")
        {
        }
    }
}
