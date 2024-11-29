namespace DosPinos.HRMS.Entities.DTOs.Reports
{
    public class LicenseReportDTO : BaseReportDTO
    {
        public string LicenseType { get; set; }
        public int Duration { get; set; }
    }
}