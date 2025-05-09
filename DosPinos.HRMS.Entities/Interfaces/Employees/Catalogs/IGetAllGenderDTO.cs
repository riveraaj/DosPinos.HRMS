namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;

/// <summary>
/// Interface for retriving all genders.
/// </summary>
public interface IGetAllGenderDTO : IEntityDTO
{
    int Id { get; }
    string Description { get; }
}