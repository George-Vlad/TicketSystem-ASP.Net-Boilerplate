using System.Threading.Tasks;
using GeorgeVlad.TicketingSystem.Configuration.Dto;

namespace GeorgeVlad.TicketingSystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
