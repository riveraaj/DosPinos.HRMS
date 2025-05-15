namespace DosPinos.HRMS.Entities.Interfaces.Holidays;

/// <summary>
/// Interface for creating a holiday.
/// </summary>
public interface ICreateHolidayDTO : IEntityDTO
{
    public string Description { get; }
    public DateOnly Date { get; }
    public bool IsMandatory { get; }
}