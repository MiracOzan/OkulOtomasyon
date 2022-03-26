using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PostSharp.Aspects;

namespace OkulOtomasyon.Core.Aspects.PostSharp.TransactionAspects
{
    [Serializable]
    public class TransactionScopeAspects : OnMethodBoundaryAspect
    {
        private TransactionScopeOption _option;
        public TransactionScopeAspects(TransactionScopeOption option)
        {
            _option = option;
        }

        public TransactionScopeAspects()
        {
            
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope(_option);
        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope) args.MethodExecutionTag).Complete();
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();

        }
    }
}
