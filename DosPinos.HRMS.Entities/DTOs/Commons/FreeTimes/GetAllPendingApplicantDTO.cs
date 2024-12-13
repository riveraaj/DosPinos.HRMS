using DosPinos.HRMS.Entities.Enums.FreeTimes;

namespace DosPinos.HRMS.Entities.DTOs.Commons.FreeTimes
{
    public class GetAllPendingApplicantDTO : EntityDTO, IEntityDTO
    {
        public int ApplicantId { get; set; }
        public ApplicationCode Code { get; set; }
        public string EmployeeName { get; set; }
        public string JobTitle { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Days { get; set; }
        public string ApplicationType { get; set; }
        public string DocumentationPath { get; set; }
    }
}