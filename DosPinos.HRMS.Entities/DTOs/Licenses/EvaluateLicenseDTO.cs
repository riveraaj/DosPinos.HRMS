namespace DosPinos.HRMS.Entities.DTOs.Licenses
{
    public class EvaluateLicenseDTO : EntityDTO, IEntityDTO
    {
        public bool IsApproved { get; set; }
        public int EmployeeId { get; set; }
        public int LicenseId { get; set; }
    }
}