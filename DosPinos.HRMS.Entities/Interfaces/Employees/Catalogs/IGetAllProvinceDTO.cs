namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;

/// <summary>
/// Interface for retrieving all provinces.
/// </summary>
public interface IGetAllProvinceDTO : IEntityDTO
{
    int Id { get; }
    string Description { get; }
}