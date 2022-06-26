using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using GeorgeVlad.TicketingSystem.Authorization;
using GeorgeVlad.TicketingSystem.Authorization.Roles;
using GeorgeVlad.TicketingSystem.Authorization.Users;
using GeorgeVlad.TicketingSystem.Editions;
using GeorgeVlad.TicketingSystem.MultiTenancy;

namespace GeorgeVlad.TicketingSystem.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>()
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpLogInManager<LogInManager>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}
