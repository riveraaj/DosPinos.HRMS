namespace DosPinos.HRMS.Entities.Interfaces.Employees.Details;

/// <summary>
/// Interface for creating an employee detail.
/// </summary>
public interface ICreateEmployeeDetailDTO : IEntityDTO
{
    DateOnly DateBirth { get; }
    int Children { get; }
    byte MaritalStatusId { get; }
    byte NationalityId { get; }
    byte GenderId { get; }
    byte HiringTypeId { get; }
    byte JobTitleId { get; }
    string Email { get; }
    DateOnly EntryDate { get; }
}