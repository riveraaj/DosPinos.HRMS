namespace DosPinos.HRMS.Entities.Interfaces.Employees.Details
{
    public interface ICreateEmployeeDetailDTO
    {
        DateOnly DateBirth { get; set; }
        int Children { get; set; }
        DateOnly DateEntry { get; set; }
        byte MaritalStatusId { get; set; }
        byte NationalityId { get; set; }
        byte GenderId { get; set; }
        byte HiringTypeId { get; set; }
        byte JobTitleId { get; set; }
    }
}