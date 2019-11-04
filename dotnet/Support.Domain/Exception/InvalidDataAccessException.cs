using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class InvalidDataAccessException : BusinessException
    {
        public InvalidDataAccessException() :
            base(ExceptionCode.InvalidDataAccess,
                "دسترسی شما به این داده مجاز نمی باشد")
        {

        }
    }
}
