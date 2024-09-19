using WebdeskEA.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Domain.RepositoryEntity.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company obj);

    }
}
