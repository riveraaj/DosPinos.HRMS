using DosPinos.HRMS.Entities.DTOs.WorkingDays;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.WorkingDays;

namespace DosPinos.HRMS.WebApp.Models.WorkingDays
{
    public class PendingWorkingDayViewModel : BaseViewModel
    {
        public PendingWorkingDayViewModel()
        {
            this.Title = WorkingDayLabel.PendingTitle;
            EvaluateWorkingDayObj = new();
            PendingWorkingDays = [];
        }

        public EvaluateWorkingDayDTO EvaluateWorkingDayObj { get; set; }
        public List<GetAllPendingWorkingDayDTO> PendingWorkingDays { get; set; }
    }
}