using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class PersonNotActiveException : BusinessException
    {
        public PersonNotActiveException()
            : base(ExceptionCode.PersonNotActiveCode, "کاربر شما فعال نمی‌باشد" + " (" + ExceptionCode.PersonNotActiveCode.ToString() + ")")
        {
        }
    }
}
