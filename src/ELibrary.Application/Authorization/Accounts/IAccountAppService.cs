using System.Threading.Tasks;
using Abp.Application.Services;
using ELibrary.Authorization.Accounts.Dto;

namespace ELibrary.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
