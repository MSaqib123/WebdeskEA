using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Utility.EnumUtality
{
    public interface IEnumService
    {
        IEnumerable<KeyValuePair<string, string>> GetTransactionTypes();
    }
}
