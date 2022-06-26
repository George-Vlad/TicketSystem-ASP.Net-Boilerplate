using Abp.Application.Services.Dto;

namespace GeorgeVlad.TicketingSystem.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

