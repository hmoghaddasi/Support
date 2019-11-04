using System;
using Castle.DynamicProxy;
using Framework.Core.UnitOfWork;

namespace Support.Config
{
    public class TransactionInterceptor : IInterceptor
    {
        private readonly IUnitOfWork unitOfWork;
        public TransactionInterceptor(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Intercept(IInvocation invocation)
        {
            var name = invocation.Method.Name;
            string nameNo = string.Empty;
            int value;

            for (int i = 0; i < name.Length; i++)
            {
                if (Char.IsDigit(name[i]))
                    nameNo += name[i];
            }

            if (nameNo.Length > 0)
            {
                value = int.Parse(nameNo);
            }
                
            if (invocation.Method.Name.StartsWith("get", StringComparison.InvariantCultureIgnoreCase))
            {
                invocation.Proceed();
                return;
            }

            unitOfWork.Begin();
            invocation.Proceed();
            unitOfWork.Commit();
        }


    }
}
