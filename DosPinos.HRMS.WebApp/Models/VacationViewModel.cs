using DosPinos.HRMS.Entities.DTOs.Vacations;

namespace DosPinos.HRMS.WebApp.Models
{
    public class VacationViewModel
    {
        public VacationViewModel()
        {
            Get = [];
            Evaluate = new();
        }

        public List<GetAllVacationPendingDTO> Get { get; set; }
        public EvaluateVacationDTO Evaluate { get; set; }
    }
}