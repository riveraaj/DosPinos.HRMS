namespace DosPinos.HRMS.Entities.DTOs.Licenses
{
    public class GetAllLicenseByEmployeeDTO
    {
        public int EmployeeId { get; set; }
        public int LicenseId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Status { get; set; }
        public string TypeLicense { get; set; }
        public int Days { get; set; }
    }
}