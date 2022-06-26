using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GeorgeVlad.TicketingSystem.EntityFrameworkCore;
using GeorgeVlad.TicketingSystem.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace GeorgeVlad.TicketingSystem.Web.Tests
{
    [DependsOn(
        typeof(TicketingSystemWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class TicketingSystemWebTestModule : AbpModule
    {
        public TicketingSystemWebTestModule(TicketingSystemEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TicketingSystemWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(TicketingSystemWebMvcModule).Assembly);
        }
    }
}