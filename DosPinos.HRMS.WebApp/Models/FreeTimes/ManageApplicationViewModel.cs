using DosPinos.HRMS.Entities.DTOs.Commons.FreeTimes;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.FreeTimes;

namespace DosPinos.HRMS.WebApp.Models.FreeTimes
{
    public class ManageApplicationViewModel : BaseViewModel
    {
        public ManageApplicationViewModel()
        {
            Title = FreeTimeLabel.PendingTitle;
            EvaluationObj = new();
            Applications = [];
        }

        public EvaluateApplicationDTO EvaluationObj { get; set; }
        public List<GetAllPendingApplicantDTO> Applications { get; set; }
    }
}