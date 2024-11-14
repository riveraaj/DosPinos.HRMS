using DosPinos.HRMS.Entities.DTOs.Employees;
using DosPinos.HRMS.Entities.DTOs.Liquidation;

namespace DosPinos.HRMS.WebApp.Models
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            Employee = new GetEmployeeByIdentifactionDTO();
            Liquidation = new CreateLiquidationDTO();
        }
        public GetEmployeeByIdentifactionDTO Employee { get; set; }
        public CreateLiquidationDTO Liquidation { get; set; }
    }
}