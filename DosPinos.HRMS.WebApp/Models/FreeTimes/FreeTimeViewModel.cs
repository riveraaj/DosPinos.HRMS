using DosPinos.HRMS.Entities.DTOs.Vacations;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.FreeTimes;

namespace DosPinos.HRMS.WebApp.Models.FreeTimes
{
    public class FreeTimeViewModel : BaseViewModel
    {
        public FreeTimeViewModel()
        {
            this.Title = FreeTimeLabel.Title;
            VacationObj = new();
            Vacations = [];
            VacationBalance = new();
            Today = string.Empty;
        }

        public CreateVacationDTO VacationObj { get; set; }
        public List<GetAllVacationByEmployeeDTO> Vacations { get; set; }
        public GetEmployeeVacationBalance VacationBalance { get; set; }
        public string Today { get; set; }
    }
}