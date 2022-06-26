using Abp.AutoMapper;
using GeorgeVlad.TicketingSystem.Sessions.Dto;

namespace GeorgeVlad.TicketingSystem.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
