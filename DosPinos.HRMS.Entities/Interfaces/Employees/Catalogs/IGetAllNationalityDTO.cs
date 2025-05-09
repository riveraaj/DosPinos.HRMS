namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;

/// <summary>
/// Interface for retrieving all nationalities.
/// </summary>
public interface IGetAllNationalityDTO : IEntityDTO
{
    int Id { get; }
    string Description { get; }
}