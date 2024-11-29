using DosPinos.HRMS.Entities.DTOs.Employees.Catalogs;
using DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;
using DosPinos.HRMS.WebApp.Models.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DosPinos.HRMS.WebApp.Models.Employees
{
    public class BaseEmployeeViewModel : BaseViewModel
    {
        public BaseEmployeeViewModel()
        {
            ManagerList = [];
            DistrictList = [];
            GenderList = [];
            NationalityList = [];
            MaritalStatusList = [];
            HiringTypeList = [];
            JobTitleList = [];
            SalaryCategoryList = [];
            PhoneTypeList = [];
            CantonList = [];
            ProvinceList = [];
        }

        public List<GetAllManagerDTO> ManagerList { get; set; }
        public List<IGetAllDistrictDTO> DistrictList { get; set; }
        public List<IGetAllCantonDTO> CantonList { get; set; }
        public List<IGetAllProvinceDTO> ProvinceList { get; set; }
        public List<IGetAllGenderDTO> GenderList { get; set; }
        public List<IGetAllNationalityDTO> NationalityList { get; set; }
        public List<IGetAllMaritalStatusDTO> MaritalStatusList { get; set; }
        public List<IGetAllHiringTypeDTO> HiringTypeList { get; set; }
        public List<IGetAllJobTitleDTO> JobTitleList { get; set; }
        public List<IGetAllSalaryCategoryDTO> SalaryCategoryList { get; set; }
        public List<IGetAllPhoneTypeDTO> PhoneTypeList { get; set; }

        public List<SelectListItem> Managers => ManagerList.Select(m => new SelectListItem
        {
            Value = m.ManagerId.ToString(),
            Text = m.ManagerName,
        }).ToList();

        public List<SelectListItem> Genders => GenderList.Select(g => new SelectListItem
        {
            Value = g.GenderId.ToString(),
            Text = g.GenderDescription
        }).ToList();

        public List<SelectListItem> Nationalities => NationalityList.Select(n => new SelectListItem
        {
            Value = n.NationalityId.ToString(),
            Text = n.NationalityDescription
        }).ToList();

        public List<SelectListItem> MaritalStatus => MaritalStatusList.Select(n => new SelectListItem
        {
            Value = n.MaritalStatusId.ToString(),
            Text = n.MaritalStatusDescription
        }).ToList();

        public List<SelectListItem> HiringTypes => HiringTypeList.Select(h => new SelectListItem
        {
            Value = h.HiringTypeId.ToString(),
            Text = h.HiringTypeDescription
        }).ToList();

        public List<SelectListItem> JobTitles => JobTitleList.Select(j => new SelectListItem
        {
            Value = j.JobTitleId.ToString(),
            Text = j.JobTitleDescription
        }).ToList();

        public List<SelectListItem> SalaryCategories => SalaryCategoryList.Select(s => new SelectListItem
        {
            Value = s.SalaryCategoryId.ToString(),
            Text = $"{s.SalaryCategoryDescription} - {s.SalaryCategoryRange:C}"
        }).ToList();

        public List<SelectListItem> PhoneTypes => PhoneTypeList.Select(p => new SelectListItem
        {
            Value = p.PhoneTypeId.ToString(),
            Text = p.PhoneTypeDescription
        }).ToList();
    }
}