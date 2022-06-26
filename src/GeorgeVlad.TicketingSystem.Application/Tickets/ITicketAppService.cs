using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GeorgeVlad.TicketingSystem.Tickets.Dto;

namespace GeorgeVlad.TicketingSystem.Tickets
{
    public interface ITicketAppService : IApplicationService
    {
        Task<PagedResultDto<TicketListDto>> GetTicketListAsync();
        Task<TicketDto> GetTicketAsync(int id);
    }
}