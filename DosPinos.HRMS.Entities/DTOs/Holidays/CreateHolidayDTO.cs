namespace DosPinos.HRMS.Entities.DTOs.Holidays;

/// <summary>
/// DTO for creating a holiday.
/// </summary>
public class CreateHolidayDTO(string description, DateOnly date,
                              bool isMandatory) : EntityDTO, ICreateHolidayDTO
{
    public string Description => description;
    public DateOnly Date => date;
    public bool IsMandatory => isMandatory;
}