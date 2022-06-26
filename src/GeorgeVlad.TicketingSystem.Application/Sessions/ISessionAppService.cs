using System.Threading.Tasks;
using Abp.Application.Services;
using GeorgeVlad.TicketingSystem.Sessions.Dto;

namespace GeorgeVlad.TicketingSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
