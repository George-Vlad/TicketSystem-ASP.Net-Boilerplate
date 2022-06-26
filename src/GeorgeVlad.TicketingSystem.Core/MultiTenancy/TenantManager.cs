using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using GeorgeVlad.TicketingSystem.Authorization.Users;
using GeorgeVlad.TicketingSystem.Editions;

namespace GeorgeVlad.TicketingSystem.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
