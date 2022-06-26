using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using GeorgeVlad.TicketingSystem.Configuration.Dto;

namespace GeorgeVlad.TicketingSystem.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TicketingSystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
