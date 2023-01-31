using Abp.Application.Services;
using ELibrary.MultiTenancy.Dto;

namespace ELibrary.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

