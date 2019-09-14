namespace Framework.Core.Exception
{
    public class ExpressionBuilderFailException : BusinessException
    {
        public ExpressionBuilderFailException()
            : base(ExceptionCode.ExpressionBuilderFailCode, "خطای Expression. با ادمین سیستم تماس بگیرید" + " (" + ExceptionCode.ExpressionBuilderFailCode.ToString() + ")")
        {
        }
    }

    public class ExceptionCode
    {
        public const int ExpressionBuilderFailCode = 1000;
        public const int NotExistConfigCode = 1001;
    }
}
