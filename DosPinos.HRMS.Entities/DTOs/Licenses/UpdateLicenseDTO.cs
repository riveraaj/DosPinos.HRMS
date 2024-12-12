namespace DosPinos.HRMS.Entities.DTOs.Licenses
{
    public class UpdateLicenseDTO : EntityDTO, IEntityDTO
    {
        public int LicenseId { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public string DocumentationPath { get; set; }
    }
}