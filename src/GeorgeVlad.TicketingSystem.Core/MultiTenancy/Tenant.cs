using Abp.MultiTenancy;
using GeorgeVlad.TicketingSystem.Authorization.Users;

namespace GeorgeVlad.TicketingSystem.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
