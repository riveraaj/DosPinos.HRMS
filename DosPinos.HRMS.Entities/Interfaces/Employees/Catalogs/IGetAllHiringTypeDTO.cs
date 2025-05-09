namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;

/// <summary>
/// Interface for getting all hiring types.
/// </summary>
public interface IGetAllHiringTypeDTO : IEntityDTO
{
    int Id { get; }
    string Description { get; }
}