using DosPinos.HRMS.Entities.Enums.FreeTimes;

namespace DosPinos.HRMS.Entities.DTOs.Commons.FreeTimes
{
    public class EvaluateApplicationDTO : EntityDTO, IEntityDTO
    {
        public int ApplicantId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsApproved { get; set; }
        public ApplicationCode Code { get; set; }
    }
}