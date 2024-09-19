using WebdeskEA.Models.MappingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Domain.RepositoryDapper.IRepository
{
    public interface ICOARepository
    {
        Task<COADto> GetByIdAsync(int id);
        Task<IEnumerable<COADto>> GetAllListAsync();
        Task<int> AddAsync(COADto Dto);
        Task<int> UpdateAsync(COADto Dto);
        Task<int> DeletesAsync(int id);
        Task<IEnumerable<COADto>> GetByNameAsync(string name);
        Task<int> BulkAddAsync(IEnumerable<COADto> Dtos);
    }
}
