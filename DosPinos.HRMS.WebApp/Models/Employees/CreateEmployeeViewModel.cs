using DosPinos.HRMS.Entities.DTOs.Employees;
using DosPinos.HRMS.Entities.Interfaces.Employees;
using DosPinos.HRMS.WebApp.Resources.Employees;

namespace DosPinos.HRMS.WebApp.Models.Employees
{
    public class CreateEmployeeViewModel : BaseEmployeeViewModel
    {
        public CreateEmployeeViewModel()
        {
            this.Title = EmployeeLabel.CreateTitle;
            EmployeeObj = new CreateEntireEmployeeDTO();
            Today = DateTime.Now.AddYears(-100).ToString("yyyy-MM-dd");
        }

        public string Today { get; }
        public ICreateEntireEmployeeDTO EmployeeObj { get; set; }
    }
}