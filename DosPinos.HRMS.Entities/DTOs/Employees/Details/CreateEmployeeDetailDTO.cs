namespace DosPinos.HRMS.Entities.DTOs.Employees.Details
{
    public class CreateEmployeeDetailDTO : ICreateEmployeeDetailDTO
    {
        public DateOnly DateBirth { get; set; }
        public int Children { get; set; }
        public byte MaritalStatusId { get; set; }
        public byte NationalityId { get; set; }
        public byte GenderId { get; set; }
        public byte HiringTypeId { get; set; }
        public byte JobTitleId { get; set; }
        public string Email { get; set; }
    }
}