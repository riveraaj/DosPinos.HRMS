using DosPinos.HRMS.Entities.DTOs.Deductions;
using DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Maintenances;

namespace DosPinos.HRMS.WebApp.Models.Maintenances.Deductions
{
    public class DeductionViewModel : BaseViewModel
    {
        public DeductionViewModel()
        {
            this.Title = MaintenanceLabel.DeductionTitle;
            DeductionObj = new();
            UpdateDeductionObj = new();
            Deductions = [];
        }

        public CreateDeductionDTO DeductionObj { get; set; }
        public UpdateDeductionDTO UpdateDeductionObj { get; set; }
        public List<IGetAllDeductionDTO> Deductions { get; set; }
    }
}