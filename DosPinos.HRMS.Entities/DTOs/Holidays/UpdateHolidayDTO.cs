namespace DosPinos.HRMS.Entities.DTOs.Holidays;

/// <summary>
/// DTO for updating a holiday.
/// </summary>
public class UpdateHolidayDTO(int id, DateOnly date,
                              bool isMandatory) : EntityDTO, IUpdateHolidayDTO
{
    public int Id => id;
    public DateOnly Date => date;
    public bool IsMandatory => isMandatory;
}