using DosPinos.HRMS.Entities.DTOs.Employees;
using DosPinos.HRMS.Entities.DTOs.Liquidation;
using DosPinos.HRMS.WebApp.Models.Base;

namespace DosPinos.HRMS.WebApp.Models.Employees
{
    public class EditEmployeeViewModel : BaseViewModel
    {
        public EditEmployeeViewModel()
        {
            this.Title = "";
            Employee = new();
            Liquidation = new();
        }

        public GetEmployeeByIdentifactionDTO Employee { get; set; }
        public CreateLiquidationDTO Liquidation { get; set; }
    }
}