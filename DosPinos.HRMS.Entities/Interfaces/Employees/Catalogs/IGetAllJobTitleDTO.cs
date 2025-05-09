namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;

/// <summary>
/// Interface for getting all job titles.
/// </summary>
public interface IGetAllJobTitleDTO : IEntityDTO
{
    int Id { get; }
    string Description { get; }
}