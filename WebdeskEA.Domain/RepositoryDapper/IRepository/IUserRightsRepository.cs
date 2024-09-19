using WebdeskEA.Models.MappingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Domain.RepositoryDapper.IRepository
{
    public interface IUserRightsRepository
    {
        Task<UserRightDto> GetByIdAsync(int id);
        Task<IEnumerable<UserRightDto>> GetAllListAsync();
        Task<IEnumerable<UserRightDto>> GetAllListByUserIdAsync(string UserId);
        Task<IEnumerable<string>> GetPermissionsByModuleIdAsync(int moduleId);
        Task<int> AddAsync(UserRightDto Dto);
        Task<int> UpdateAsync(UserRightDto Dto);
        Task<int> DeletesAsync(int id);
        Task<IEnumerable<UserRightDto>> GetByNameAsync(string name);
        Task<int> BulkAddAsync(IEnumerable<UserRightDto> Dtos);
        Task<int> DeletesAllRightsOfUserAsync(string id);
        Task<IEnumerable<string>> GetExistingPermissinDyanmicListAsync();
    }
}
