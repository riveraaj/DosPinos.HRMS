using DosPinos.HRMS.Entities.DTOs.WorkingDays;

namespace DosPinos.HRMS.WebApp.Models
{
    public class WorkingDayViewModel
    {
        public WorkingDayViewModel()
        {
            Create = new();
            Get = [];
        }

        public CreateWorkingDayDTO Create { get; set; }
        public List<GetAllWorkingDayByDayDTO> Get { get; set; }
    }
}