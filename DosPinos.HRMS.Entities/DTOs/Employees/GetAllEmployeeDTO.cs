namespace DosPinos.HRMS.Entities.DTOs.Employees;

/// <summary>
/// DTO for get all employee
/// </summary>
public class GetAllEmployeeDTO(string identification,
                               string fullname,
                               string jobTitle,
                               DateOnly dateEntry,
                               string hiringType,
                               string manager) : EntityDTO, IGetAllEmployeeDTO
{
    public string Identification => identification;
    public string Fullname => fullname;
    public string JobTitle => jobTitle;
    public DateOnly DateEntry => dateEntry;
    public string HiringType => hiringType;
    public string Manager => manager;
}