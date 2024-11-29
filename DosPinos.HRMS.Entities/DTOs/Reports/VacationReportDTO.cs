namespace DosPinos.HRMS.Entities.DTOs.Reports
{
    public class VacationReportDTO : BaseReportDTO
    {
        public int Total { get; set; }
        public int UsedDays { get; set; }
        public int RemainingDays { get; set; }
        public string Status { get; set; }
    }
}