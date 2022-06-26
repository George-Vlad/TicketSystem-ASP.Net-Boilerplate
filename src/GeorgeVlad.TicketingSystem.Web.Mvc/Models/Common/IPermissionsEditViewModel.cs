using System.Collections.Generic;
using GeorgeVlad.TicketingSystem.Roles.Dto;

namespace GeorgeVlad.TicketingSystem.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}