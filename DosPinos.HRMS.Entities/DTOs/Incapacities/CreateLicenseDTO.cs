namespace DosPinos.HRMS.Entities.DTOs.Incapacities
{
    public class CreateLicenseDTO : EntityDTO, IEntityDTO
    {
        public int EmployeeId { get; set; }
        public int LicenseTypeId { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public string DocumentationPath { get; set; }
        public int ManagerId { get; set; }
    }
}