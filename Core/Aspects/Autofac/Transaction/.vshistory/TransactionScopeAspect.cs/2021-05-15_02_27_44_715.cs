﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Aspects.Autofac.Transaction
{
    ////Transactional  yönetimi : Uygulamalarda , tutarlılığı korumak için yaptığımız bir yöntem.
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
