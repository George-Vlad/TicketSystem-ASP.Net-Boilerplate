using Abp.Application.Services;
using GeorgeVlad.TicketingSystem.MultiTenancy.Dto;

namespace GeorgeVlad.TicketingSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

