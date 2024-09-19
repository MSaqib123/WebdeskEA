using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Utility.EnumUtality.AllEnumes
{
    public enum TransactionType
    {
        Credit = 1,
        Debit = 2
    }

    public static class TransactionTypeExtensions
    {
        private static readonly Dictionary<TransactionType, string> TransactionTypeMap = new Dictionary<TransactionType, string>
        {
            { TransactionType.Credit, "CRE" },
            { TransactionType.Debit, "DEB" }
        };

        public static string GetCode(this TransactionType transactionType)
        {
            return TransactionTypeMap[transactionType];
        }
    }
}
