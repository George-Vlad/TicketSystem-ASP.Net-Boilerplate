using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GeorgeVlad.TicketingSystem.Configuration;
using GeorgeVlad.TicketingSystem.EntityFrameworkCore;
using GeorgeVlad.TicketingSystem.Migrator.DependencyInjection;

namespace GeorgeVlad.TicketingSystem.Migrator
{
    [DependsOn(typeof(TicketingSystemEntityFrameworkModule))]
    public class TicketingSystemMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public TicketingSystemMigratorModule(TicketingSystemEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(TicketingSystemMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                TicketingSystemConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TicketingSystemMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
