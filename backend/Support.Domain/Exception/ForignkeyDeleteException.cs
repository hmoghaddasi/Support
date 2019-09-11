namespace Support.Domain.Exception
{
    public class ForignkeyDeleteException : BusinessException
    {
        public ForignkeyDeleteException()
            : base(ExceptionCode.ForignKeyDeleteCode,
                  "به علت وجود وابستگی داده امکان حذف این آیتم وجود ندارد" +" ("+
                  ExceptionCode.ForignKeyDeleteCode.ToString() + ")")
        {
        }
    }
}


