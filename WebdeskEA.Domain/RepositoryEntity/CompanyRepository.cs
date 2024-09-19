using WebdeskEA.DataAccess;
using WebdeskEA.Domain.RepositoryEntity.IRepository;
using WebdeskEA.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Domain.RepositoryEntity
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private WebdeskEA20240706Context _db;
        public CompanyRepository(WebdeskEA20240706Context db) : base(db)
        {
            _db = db;
        }

        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }
    }
}
