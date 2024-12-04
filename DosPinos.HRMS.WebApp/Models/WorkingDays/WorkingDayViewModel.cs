using DosPinos.HRMS.Entities.DTOs.WorkingDays;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.WorkingDays;

namespace DosPinos.HRMS.WebApp.Models.WorkingDays
{
    public class WorkingDayViewModel : BaseViewModel
    {
        public WorkingDayViewModel()
        {
            this.Title = WorkingDayLabel.Title;
            WorkingDayObj = new();
            WorkinDays = [];
        }

        public CreateWorkingDayDTO WorkingDayObj { get; set; }
        public List<GetAllWorkingDayByDayDTO> WorkinDays { get; set; }
        public string Today { get; set; }
    }
}