namespace Support.Domain.Exception
{
    public class PersonNotFoundException : BusinessException
    {
        public PersonNotFoundException()
            : base(ExceptionCode.PersonNotFoundCode, "کاربر مورد نظر وجود ندارد " + " (" + ExceptionCode.PersonNotFoundCode.ToString() + ")")
        {
        }
    }
}
