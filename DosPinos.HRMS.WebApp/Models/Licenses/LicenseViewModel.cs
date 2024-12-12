using DosPinos.HRMS.Entities.DTOs.Licenses;
using DosPinos.HRMS.Entities.Interfaces.Licenses.Catalogs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DosPinos.HRMS.WebApp.Models.Licenses
{
    public class LicenseViewModel
    {
        public LicenseViewModel()
        {
            LicenseObj = new();
            Licenses = [];
            LicenseTypeList = [];
        }

        public CreateLicenseDTO LicenseObj { get; set; }
        public List<GetAllLicenseByEmployeeDTO> Licenses { get; set; }
        public List<IGetAllLicenseTypeDTO> LicenseTypeList { get; set; }
        public IFormFile FormFile { get; set; } = null;
        public List<SelectListItem> LicensesTypes => LicenseTypeList.Select(l => new SelectListItem
        {
            Value = l.LicenseTypeId.ToString(),
            Text = l.LicenseTypeDescription,
        }).ToList();
    }
}
