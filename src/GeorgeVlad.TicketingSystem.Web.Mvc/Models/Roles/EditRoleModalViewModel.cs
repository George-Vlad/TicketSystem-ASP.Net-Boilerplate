using Abp.AutoMapper;
using GeorgeVlad.TicketingSystem.Roles.Dto;
using GeorgeVlad.TicketingSystem.Web.Models.Common;

namespace GeorgeVlad.TicketingSystem.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
