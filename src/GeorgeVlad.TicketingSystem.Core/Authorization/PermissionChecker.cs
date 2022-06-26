using Abp.Authorization;
using GeorgeVlad.TicketingSystem.Authorization.Roles;
using GeorgeVlad.TicketingSystem.Authorization.Users;

namespace GeorgeVlad.TicketingSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
