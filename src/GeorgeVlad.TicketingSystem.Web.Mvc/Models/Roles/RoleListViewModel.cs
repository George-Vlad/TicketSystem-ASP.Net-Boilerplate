using System.Collections.Generic;
using GeorgeVlad.TicketingSystem.Roles.Dto;

namespace GeorgeVlad.TicketingSystem.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
