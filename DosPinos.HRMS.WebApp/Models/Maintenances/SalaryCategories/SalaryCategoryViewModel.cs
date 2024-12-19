using DosPinos.HRMS.Entities.DTOs.SalaryCategories;
using DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Maintenances;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DosPinos.HRMS.WebApp.Models.Maintenances.SalaryCategories
{
    public class SalaryCategoryViewModel : BaseViewModel
    {
        public SalaryCategoryViewModel()
        {
            this.Title = MaintenanceLabel.SalaryCategoryTitle;
            SalaryCategoryObj = new();
            SalaryCategories = [];
            IncomeTaxList = [];
        }

        public CreateSalaryCategoryDTO SalaryCategoryObj { get; set; }
        public List<IGetAllSalaryCategoryDTO> SalaryCategories { get; set; }
        public List<IGetAllIncomeTaxDTO> IncomeTaxList { get; set; }
        public List<SelectListItem> IncomeTaxes => IncomeTaxList.Select(m => new SelectListItem
        {
            Value = m.IncomeTaxId.ToString(),
            Text = m.IncomeTaxPercentage.ToString(),
        }).ToList();
    }
}