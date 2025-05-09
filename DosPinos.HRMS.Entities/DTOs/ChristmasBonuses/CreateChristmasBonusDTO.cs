namespace DosPinos.HRMS.Entities.DTOs.ChristmasBonuses;

/// <summary>
/// DTO for creating a Christmas bonus.
/// This DTO is used to encapsulate the necessary 
/// data for creating a Christmas bonus in the HRMS system.
/// </summary>
/// <remarks>
/// Implements <see cref="EntityDTO"/> and <see cref="ICreateChristmasBonusDTO"/>.
/// </remarks>
public class CreateChristmasBonusDTO(int employeeId,
                                     int year, int date) : EntityDTO, ICreateChristmasBonusDTO
{
    public int EmployeeId => employeeId;
    public int Year => year;
    public int Date => date;
}