using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GeorgeVlad.TicketingSystem.Configuration;

namespace GeorgeVlad.TicketingSystem.Web.Host.Startup
{
    [DependsOn(
       typeof(TicketingSystemWebCoreModule))]
    public class TicketingSystemWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TicketingSystemWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TicketingSystemWebHostModule).GetAssembly());
        }
    }
}
