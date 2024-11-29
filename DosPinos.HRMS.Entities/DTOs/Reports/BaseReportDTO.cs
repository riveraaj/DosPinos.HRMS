namespace DosPinos.HRMS.Entities.DTOs.Reports
{
    public class BaseReportDTO
    {
        public int Identification { get; set; }
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public DateOnly Date { get; set; }
    }
}