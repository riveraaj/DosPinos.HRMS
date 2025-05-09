namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;

/// <summary>
/// Interface for retrieving all districts.
/// </summary>
public interface IGetAllDistrictDTO : IEntityDTO
{
    int Id { get; }
    string Description { get; }
    int CantonId { get; }
}