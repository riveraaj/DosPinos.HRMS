using DosPinos.HRMS.Entities.DTOs.Reports;
using DosPinos.HRMS.WebApp.Models.Base;

namespace DosPinos.HRMS.WebApp.Models.Reports
{
    public class ReportVacationViewModel : BaseViewModel
    {
        public ReportVacationViewModel()
        {
            this.Title = "Reporte";
            Vacation = [];
        }

        public List<VacationReportDTO> Vacation { get; set; }
    }
}
