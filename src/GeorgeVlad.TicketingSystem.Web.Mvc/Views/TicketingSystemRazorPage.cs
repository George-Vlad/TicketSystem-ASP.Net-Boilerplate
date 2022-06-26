using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace GeorgeVlad.TicketingSystem.Web.Views
{
    public abstract class TicketingSystemRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected TicketingSystemRazorPage()
        {
            LocalizationSourceName = TicketingSystemConsts.LocalizationSourceName;
        }
    }
}
