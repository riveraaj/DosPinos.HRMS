namespace DosPinos.HRMS.Entities.DTOs.Reports
{
    public class SpecialPermissionReportDTO : BaseReportDTO
    {
        public string SpecialPermissionType { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; }
    }
}