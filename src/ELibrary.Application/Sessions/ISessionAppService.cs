using System.Threading.Tasks;
using Abp.Application.Services;
using ELibrary.Sessions.Dto;

namespace ELibrary.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
