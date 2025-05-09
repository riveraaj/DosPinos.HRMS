namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;

/// <summary>
/// Interface for retrieving all salary categories.
/// </summary>
public interface IGetAllSalaryCategoryDTO : IEntityDTO
{
    int Id { get; }
    string Description { get; }
    decimal Range { get; }
}