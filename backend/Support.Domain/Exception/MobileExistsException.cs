namespace Support.Domain.Exception
{
    public class MobileExistsException : BusinessException
    {
        public MobileExistsException() :
            base(ExceptionCode.MobileExists,
                "Your mobile number is already registered ( Error Code : " +
                ExceptionCode.MobileExists + " )")
        {

        }
    }
}
