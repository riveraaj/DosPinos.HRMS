namespace DosPinos.HRMS.Entities.Interfaces.ChristmasBonuses;

/// <summary>
/// Interface for creating a Christmas bonus.
/// This interface is used to encapsulate the necessary data for 
/// creating a Christmas bonus in the HRMS system.
/// </summary>
/// <remarks>
/// Implements <see cref="IEntityDTO"/>
/// </remarks>
public interface ICreateChristmasBonusDTO : IEntityDTO
{
    int EmployeeId { get; }
    int Year { get; }
    int Date { get; }
}