using DosPinos.HRMS.Entities.DTOs.Incapacities;
using DosPinos.HRMS.Entities.DTOs.Permissions;
using DosPinos.HRMS.Entities.DTOs.Permissions.Catalogs;
using DosPinos.HRMS.Entities.DTOs.Vacations;
using DosPinos.HRMS.Entities.Interfaces.Incapacities.Catalogs;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.FreeTimes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DosPinos.HRMS.WebApp.Models.FreeTimes
{
    public class FreeTimeViewModel : BaseViewModel
    {
        public FreeTimeViewModel()
        {
            this.Title = FreeTimeLabel.Title;
            VacationObj = new();
            LicenseObj = new();
            PermissionObj = new();
            VacationBalance = new();
            Vacations = [];
            Licenses = [];
            Permissions = [];
            LicenseTypeList = [];
            PermissionTypeList = [];
            Today = string.Empty;
        }
        public string Today { get; set; }
        public CreateVacationDTO VacationObj { get; set; }
        public CreateLicenseDTO LicenseObj { get; set; }
        public CreatePermissionDTO PermissionObj { get; set; }
        public GetEmployeeVacationBalance VacationBalance { get; set; }
        public List<GetAllVacationByEmployeeDTO> Vacations { get; set; }
        public List<GetAllLicenseByEmployeeDTO> Licenses { get; set; }
        public List<GetAllPermissionByEmployeeDTO> Permissions { get; set; }
        public List<IGetAllIncapacityTypeDTO> LicenseTypeList { get; set; }
        public List<GetAllPermissionTypeDTO> PermissionTypeList { get; set; }
        public List<SelectListItem> LicenseTypes => LicenseTypeList.Select(l => new SelectListItem
        {
            Value = l.IncapacityTypeId.ToString(),
            Text = l.IncapacityTypeDescription,
        }).ToList();
        public List<SelectListItem> PermissionsTypes => PermissionTypeList.Select(p => new SelectListItem
        {
            Value = p.PermissionTypeId.ToString(),
            Text = p.PermissionTypeDescription,
        }).ToList();
    }
}