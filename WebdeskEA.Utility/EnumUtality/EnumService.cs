using WebdeskEA.Utility.EnumUtality.AllEnumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Utility.EnumUtality
{
    public class EnumService : IEnumService
    {
        public IEnumerable<KeyValuePair<string, string>> GetTransactionTypes()
        {
            return Enum.GetValues(typeof(TransactionType))
                       .Cast<TransactionType>()
                       .Select(e => new KeyValuePair<string, string>(e.GetCode(), e.ToString()));
        }
    }
}
