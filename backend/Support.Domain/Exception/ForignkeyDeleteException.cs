using Framework.Core.Exception;

namespace Support.Domain.Exception
{
    public class ForignkeyDeleteException : BusinessException
    {
        public ForignkeyDeleteException()
            : base(ExceptionCode.ForeignKeyDeleteCode,
                  "به علت وجود وابستگی داده امکان حذف این آیتم وجود ندارد" +" ("+
                  ExceptionCode.ForeignKeyDeleteCode.ToString() + ")")
        {
        }
    }
}


