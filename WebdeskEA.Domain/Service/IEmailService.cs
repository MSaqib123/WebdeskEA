using Proj.Models.ViewModel;

namespace Proj.DataAccess.Service
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailVM vm);
    }
}