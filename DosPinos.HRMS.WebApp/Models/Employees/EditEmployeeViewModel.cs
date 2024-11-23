using DosPinos.HRMS.Entities.DTOs.Employees;
using DosPinos.HRMS.Entities.DTOs.Liquidation;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Employees;

namespace DosPinos.HRMS.WebApp.Models.Employees
{
    public class EditEmployeeViewModel : BaseViewModel
    {
        public EditEmployeeViewModel()
        {
            this.Title = EmployeeLabel.EditTitle;
            Employee = new();
            Liquidation = new();
        }

        public GetEmployeeByIdentifactionDTO Employee { get; set; }
        public CreateLiquidationDTO Liquidation { get; set; }
    }
}