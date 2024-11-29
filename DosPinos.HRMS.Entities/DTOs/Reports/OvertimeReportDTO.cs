namespace DosPinos.HRMS.Entities.DTOs.Reports
{
    public class OvertimeReportDTO : BaseReportDTO
    {
        public decimal TotalAccrued { get; set; }
        public decimal Exccess { get; set; }
    }
}