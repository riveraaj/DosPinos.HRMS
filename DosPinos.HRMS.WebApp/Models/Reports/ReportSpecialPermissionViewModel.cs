using DosPinos.HRMS.Entities.DTOs.Reports;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Reports;

namespace DosPinos.HRMS.WebApp.Models.Reports
{
    public class ReportSpecialPermissionViewModel : BaseViewModel
    {
        public ReportSpecialPermissionViewModel()
        {
            this.Title = ReportLabel.PermissionReportTitle;
            SpecialPermission = [];
        }

        public List<SpecialPermissionReportDTO> SpecialPermission { get; set; }
    }
}