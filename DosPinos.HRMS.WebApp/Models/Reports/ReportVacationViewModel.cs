using DosPinos.HRMS.Entities.DTOs.Reports;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Reports;

namespace DosPinos.HRMS.WebApp.Models.Reports
{
    public class ReportVacationViewModel : BaseViewModel
    {
        public ReportVacationViewModel()
        {
            this.Title = ReportLabel.VacationReportTitle;
            Vacation = [];
        }

        public List<VacationReportDTO> Vacation { get; set; }
    }
}
