using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GeorgeVlad.TicketingSystem.Authorization;

namespace GeorgeVlad.TicketingSystem
{
    [DependsOn(
        typeof(TicketingSystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TicketingSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TicketingSystemAuthorizationProvider>();

            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);

        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TicketingSystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
