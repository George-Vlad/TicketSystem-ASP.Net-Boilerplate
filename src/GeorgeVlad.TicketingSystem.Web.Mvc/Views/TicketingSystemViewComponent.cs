using Abp.AspNetCore.Mvc.ViewComponents;

namespace GeorgeVlad.TicketingSystem.Web.Views
{
    public abstract class TicketingSystemViewComponent : AbpViewComponent
    {
        protected TicketingSystemViewComponent()
        {
            LocalizationSourceName = TicketingSystemConsts.LocalizationSourceName;
        }
    }
}
