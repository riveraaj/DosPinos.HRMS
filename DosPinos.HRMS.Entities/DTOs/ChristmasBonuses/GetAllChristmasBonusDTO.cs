namespace DosPinos.HRMS.Entities.DTOs.ChristmasBonuses;

/// <summary>
/// DTO for retrieving all Christmas bonuses.
/// This class is used to encapsulate the data 
/// related to Christmas bonuses for employees.
/// </summary>
/// <remarks>
/// Implements <see cref="EntityDTO"/> and <see cref="IGetAllChristmasBonusDTO"/>.
/// </remarks>
public class GetAllChristmasBonusDTO(int employeeId, int identification,
                                     string fullname, string job,
                                     decimal amount, DateOnly date,
                                     bool isConfirmated) : EntityDTO, IGetAllChristmasBonusDTO
{
    public int EmployeeId => employeeId;
    public int Identification => identification;
    public string FullName => fullname;
    public string Job => job;
    public decimal Amount => amount;
    public DateOnly Date => date;
    public bool IsConfirmated => isConfirmated;
}