using System.Collections.Generic;
using GeorgeVlad.TicketingSystem.Roles.Dto;

namespace GeorgeVlad.TicketingSystem.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
