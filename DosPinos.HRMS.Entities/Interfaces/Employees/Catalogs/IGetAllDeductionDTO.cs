namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;

/// <summary>
/// Interface for retrieving all deductions.
/// </summary>
public interface IGetAllDeductionDTO : IEntityDTO
{
    int Id { get; }
    string Description { get; }
    decimal Percentage { get; }
}