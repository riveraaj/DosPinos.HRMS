namespace DosPinos.HRMS.Entities.Interfaces.Employees;

/// <summary>
/// Interface for get all employee
/// </summary>
public interface IGetAllEmployeeDTO : IEntityDTO
{
    string Identification { get; }
    string Fullname { get; }
    string JobTitle { get; }
    DateOnly DateEntry { get; }
    string HiringType { get; }
    string Manager { get; }
}