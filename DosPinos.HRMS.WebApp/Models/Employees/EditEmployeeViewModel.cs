using DosPinos.HRMS.Entities.DTOs.Employees;
using DosPinos.HRMS.Entities.DTOs.Employees.Deductions;
using DosPinos.HRMS.Entities.DTOs.Liquidation;
using DosPinos.HRMS.Entities.DTOs.Rewards;
using DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;
using DosPinos.HRMS.WebApp.Resources.Employees;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DosPinos.HRMS.WebApp.Models.Employees
{
    public class EditEmployeeViewModel : BaseEmployeeViewModel
    {
        public EditEmployeeViewModel()
        {
            this.Title = EmployeeLabel.EditTitle;
            EmployeeObj = new();
            LiquidationObj = new();
            RewardObj = new();
            EmployeeDeductions = [];
            DeductionList = [];
            Today = DateTime.Now.AddYears(-100).ToString("yyyy-MM-dd");
        }

        public string Today { get; set; }
        public GetEmployeeByIdentificationDTO EmployeeObj { get; set; }
        public CreateLiquidationDTO LiquidationObj { get; set; }
        public CreateRewardDTO RewardObj { get; set; }
        public UpdateEntireEmployeeDTO UpdateEmployeeObj { get; set; }
        public List<GetAllEmployeeDeductionDTO> EmployeeDeductions { get; set; }
        public List<IGetAllDeductionDTO> DeductionList { get; set; }

        public List<SelectListItem> Provinces => ProvinceList.Select(m => new SelectListItem
        {
            Value = m.ProvinceId.ToString(),
            Text = m.ProvinceDescription,
        }).ToList();

        public List<SelectListItem> Cantons => CantonList.Select(m => new SelectListItem
        {
            Value = m.CantonId.ToString(),
            Text = m.CantonDescription,
        }).ToList();

        public List<SelectListItem> Districts => DistrictList.Select(m => new SelectListItem
        {
            Value = m.DistrictId.ToString(),
            Text = m.DistrictDescription,
        }).ToList();

        public List<SelectListItem> Deductions => DeductionList.Select(d => new SelectListItem
        {
            Value = d.DeductionId.ToString(),
            Text = d.DeductionDescription,
        }).ToList();
    }
}