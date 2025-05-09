namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;

/// <summary>
/// Interface for retrieving all marital status.
/// </summary>
public interface IGetAllMaritalStatusDTO : IEntityDTO
{
    int Id { get; }
    string Description { get; }
}