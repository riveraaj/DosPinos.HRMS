using DosPinos.HRMS.Entities.DTOs.WorkingDays;

namespace DosPinos.HRMS.WebApp.Models
{
    public class PendingWorkingDayViewModel
    {
        public PendingWorkingDayViewModel()
        {
            Evaluate = new();
            Get = [];
        }
        public EvaluateWorkingDayDTO Evaluate { get; set; }
        public List<GetAllPendingWorkingDayDTO> Get { get; set; }
    }
}