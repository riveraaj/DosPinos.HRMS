using DosPinos.HRMS.Entities.DTOs.Commons.Dashboards;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Dashboards;

namespace DosPinos.HRMS.WebApp.Models.Dashboards
{
    public class DashboardViewModel : BaseViewModel
    {
        public DashboardViewModel()
        {
            Title = DashboardLabel.Title;
            Employees = new();
            CloseVacations = [];
            EmployeesExcessOvertime = [];
            Vacations = [];
            Licenses = new();
        }

        public GetAllActiveEmployeesDTO Employees { get; set; }
        public List<GetAllCloseVacationDTO> CloseVacations { get; set; }
        public List<GetAllEmployeesExcessOvertimeDTO> EmployeesExcessOvertime { get; set; }
        public List<GetAllEmployeesVacationDTO> Vacations { get; set; }
        public GetAllEmployeesLicenseDTO Licenses { get; set; }
    }
}