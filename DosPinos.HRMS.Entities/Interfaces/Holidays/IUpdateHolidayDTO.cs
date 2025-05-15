namespace DosPinos.HRMS.Entities.Interfaces.Holidays;

/// <summary>
/// Interface for updating a holiday.
/// </summary>
public interface IUpdateHolidayDTO : IEntityDTO
{
    public int Id { get; }
    public DateOnly Date { get; }
    public bool IsMandatory { get; }
}