using DosPinos.HRMS.Entities.DTOs.Vacations;

namespace DosPinos.HRMS.WebApp.Models.Vacations
{
    public class VacationViewModel
    {
        public VacationViewModel()
        {
            VacationObj = new();
            VacationBalance = new();
            Vacations = [];
        }

        public CreateVacationDTO VacationObj { get; set; }
        public GetEmployeeVacationBalance VacationBalance { get; set; }
        public List<GetAllVacationByEmployeeDTO> Vacations { get; set; }
    }
}