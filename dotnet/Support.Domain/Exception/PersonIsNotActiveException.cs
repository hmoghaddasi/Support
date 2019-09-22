using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class PersonIsNotActiveException : BusinessException
    {
        public PersonIsNotActiveException() :
            base(Framework.Core.Exception.ExceptionCode.PersonIsNotActiveCode,
                "حساب کاربری شما فعال نمی باشد")
        {

        }
    }
}
