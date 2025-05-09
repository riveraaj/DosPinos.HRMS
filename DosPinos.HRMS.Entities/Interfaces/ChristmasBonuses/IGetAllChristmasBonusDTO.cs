namespace DosPinos.HRMS.Entities.Interfaces.ChristmasBonuses;

/// <summary>
/// Interface for retrieving all Christmas bonuses.
/// This class is used to encapsulate the data related 
/// to Christmas bonuses for employees.
/// </summary>
/// <remark>
/// Implements <see cref="IEntityDTO"/>
/// </remark>
public interface IGetAllChristmasBonusDTO : IEntityDTO
{
    int EmployeeId { get; }
    int Identification { get; }
    string FullName { get; }
    string Job { get; }
    decimal Amount { get; }
    DateOnly Date { get; }
    bool IsConfirmated { get; }
}