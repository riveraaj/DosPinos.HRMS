namespace DosPinos.HRMS.Entities.Interfaces.Employees.Details;

/// <summary>
/// Interface for updating employee details.
/// </summary>
internal interface IUpdateEmployeeDetailDTO : IEntityDTO
{
    int EmployeeId { get; }
    DateOnly DateBirth { get; }
    int Children { get; }
    int MaritalStatusId { get; }
    int NationalityId { get; }
    int GenderId { get; }
    int HiringTypeId { get; }
    int JobTitleId { get; }
}