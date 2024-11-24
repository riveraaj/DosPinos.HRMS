using DosPinos.HRMS.Entities.DTOs.Employees;
using DosPinos.HRMS.Entities.Interfaces.Employees;
using DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Employees;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DosPinos.HRMS.WebApp.Models.Employees
{
    public class CreateEmployeeViewModel : BaseViewModel
    {
        public CreateEmployeeViewModel()
        {
            this.Title = EmployeeLabel.CreateTitle;
            EmployeeObj = new CreateEntireEmployeeDTO();
            Managers = [];
            DistrictList = [];
            GenderList = [];
            NationalityList = [];
            MaritalStatusList = [];
            HiringTypeList = [];
            JobTitleList = [];
            SalaryCategoryList = [];
            PhoneTypeList = [];
            Today = DateTime.Now.AddYears(-100).ToString("yyyy-MM-dd");
        }
        public string Today { get; }
        public ICreateEntireEmployeeDTO EmployeeObj { get; set; }

        public List<IGetAllDistrictDTO> DistrictList { get; set; }
        public List<IGetAllGenderDTO> GenderList { get; set; }
        public List<IGetAllNationalityDTO> NationalityList { get; set; }
        public List<IGetAllMaritalStatusDTO> MaritalStatusList { get; set; }
        public List<IGetAllHiringTypeDTO> HiringTypeList { get; set; }
        public List<IGetAllJobTitleDTO> JobTitleList { get; set; }
        public List<IGetAllSalaryCategoryDTO> SalaryCategoryList { get; set; }
        public List<IGetAllPhoneTypeDTO> PhoneTypeList { get; set; }

        public List<SelectListItem> Managers { get; set; }
        public List<SelectListItem> Districts => DistrictList.Select(d => new SelectListItem
        {
            Value = d.DistrictId.ToString(),
            Text = d.DistrictDescription
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
            Text = s.SalaryCategoryDescription
        }).ToList();

        public List<SelectListItem> PhoneTypes => PhoneTypeList.Select(p => new SelectListItem
        {
            Value = p.PhoneTypeId.ToString(),
            Text = p.PhoneTypeDescription
        }).ToList();
    }
}