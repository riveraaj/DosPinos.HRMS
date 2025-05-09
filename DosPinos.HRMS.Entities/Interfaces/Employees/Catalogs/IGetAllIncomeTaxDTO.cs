namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;

/// <summary>
/// Interface for retrieving all income tax.
/// </summary>
public interface IGetAllIncomeTaxDTO : IEntityDTO
{
    int Id { get; }
    decimal Percentage { get; }
}