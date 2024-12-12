using DosPinos.HRMS.Entities.DTOs.Permissions;
using DosPinos.HRMS.Entities.DTOs.Permissions.Catalogs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DosPinos.HRMS.WebApp.Models.Permissions
{
    public class PermissionViewModel
    {
        public PermissionViewModel()
        {
            PermissionObj = new();
            Permissions = [];
            PermissionTypeList = [];
        }

        public CreatePermissionDTO PermissionObj { get; set; }
        public List<GetAllPermissionByEmployeeDTO> Permissions { get; set; }
        public List<GetAllPermissionTypeDTO> PermissionTypeList { get; set; }
        public IFormFile FormFile { get; set; } = null;

        public List<SelectListItem> PermissionsTypes => PermissionTypeList.Select(p => new SelectListItem
        {
            Value = p.PermissionTypeId.ToString(),
            Text = p.PermissionTypeDescription,
        }).ToList();
    }
}