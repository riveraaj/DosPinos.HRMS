namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;

/// <summary>
/// Interface for retrieving all managers.
/// </summary>
public interface IGetAllManagerDTO : IEntityDTO
{
    int Id { get; }
    string FullName { get; }
}