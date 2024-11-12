namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Details.POCOs
{
    public interface ICreateEmployeeDetailPOCO
    {
        DateOnly DateBirth { get; set; }
        int Children { get; set; }
        byte MaritalStatusId { get; set; }
        byte NationalityId { get; set; }
        byte GenderId { get; set; }
        byte HiringTypeId { get; set; }
        byte JobTitleId { get; set; }
        string Email { get; set; }
    }
}