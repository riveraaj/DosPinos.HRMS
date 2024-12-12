using DosPinos.HRMS.Entities.DTOs.Commons.Images;

namespace DosPinos.HRMS.Entities.DTOs.Licenses
{
    public class CreateLicenseDTO : EntityDTO, IEntityDTO
    {
        public CreateLicenseDTO() => ImageObj = new();

        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public string DocumentationPath { get; set; }
        public int LicenseTypeId { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public ImageDataDTO ImageObj { get; set; }
    }
}