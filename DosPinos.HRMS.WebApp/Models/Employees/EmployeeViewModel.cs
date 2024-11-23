using DosPinos.HRMS.Entities.Interfaces.Employees;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Employees;

namespace DosPinos.HRMS.WebApp.Models.Employees
{
    public class EmployeeViewModel : BaseViewModel
    {
        public EmployeeViewModel()
        {
            this.Title = EmployeeLabel.Title;
            Employees = [];
        }

        public List<IGetAllEmployeeDTO> Employees { get; set; }
    }
}