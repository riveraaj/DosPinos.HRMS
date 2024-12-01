using DosPinos.HRMS.Entities.DTOs.Reports;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Reports;

namespace DosPinos.HRMS.WebApp.Models.Reports
{
    public class ReportOvertimeViewModel : BaseViewModel
    {

        public ReportOvertimeViewModel()
        {
            this.Title = ReportLabel.OvertimeReportTitle;
            Overtime = [];
        }

        public List<OvertimeReportDTO> Overtime { get; set; }
    }
}
