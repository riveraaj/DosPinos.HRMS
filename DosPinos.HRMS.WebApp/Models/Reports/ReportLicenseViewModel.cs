using DosPinos.HRMS.Entities.DTOs.Reports;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Reports;

namespace DosPinos.HRMS.WebApp.Models.Reports
{
    public class ReportLicenseViewModel : BaseViewModel
    {
        public ReportLicenseViewModel()
        {
            this.Title = ReportLabel.LicenseReportTitle;
            License = [];
        }

        public List<LicenseReportDTO> License { get; set; }
    }
}