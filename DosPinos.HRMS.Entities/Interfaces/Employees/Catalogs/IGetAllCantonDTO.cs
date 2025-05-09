namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;

/// <summary>
/// Interface for retrieving all cantons.
/// </summary>
public interface IGetAllCantonDTO : IEntityDTO
{
    int Id { get; }
    string Description { get; }
    int ProvinceId { get; }
}