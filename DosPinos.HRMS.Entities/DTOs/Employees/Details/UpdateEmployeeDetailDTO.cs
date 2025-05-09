namespace DosPinos.HRMS.Entities.DTOs.Employees.Details;

/// <summary>
/// DTO for updating employee details.
/// </summary>
public class UpdateEmployeeDetailDTO(int employeeId,
                                     DateOnly dateBirth,
                                     int children,
                                     int maritalStatusId,
                                     int nationalityId,
                                     int genderId,
                                     int hiringTypeId,
                                     int jobTitleId) : EntityDTO, IUpdateEmployeeDetailDTO
{
    public int EmployeeId => employeeId;
    public DateOnly DateBirth => dateBirth;
    public int Children => children;
    public int MaritalStatusId => maritalStatusId;
    public int NationalityId => nationalityId;
    public int GenderId => genderId;
    public int HiringTypeId => hiringTypeId;
    public int JobTitleId => jobTitleId;
}