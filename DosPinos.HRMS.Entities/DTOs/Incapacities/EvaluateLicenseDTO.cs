namespace DosPinos.HRMS.Entities.DTOs.Incapacities
{
    public class EvaluateLicenseDTO : EntityDTO, IEntityDTO
    {
        public bool IsApproved { get; set; }
        public int EmployeeId { get; set; }
        public int LicenseId { get; set; }
    }
}