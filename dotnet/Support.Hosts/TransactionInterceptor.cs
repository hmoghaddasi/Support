using System;
using Castle.DynamicProxy;
using Framework.Core.UnitOfWork;

namespace Support.Hosts
{
    public class TransactionInterceptor : IInterceptor
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionInterceptor(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.Name.StartsWith("get", StringComparison.InvariantCultureIgnoreCase))
            {
                invocation.Proceed();
                return;
            }

            _unitOfWork.Begin();
            invocation.Proceed();
            _unitOfWork.Commit();
        }
    }
}