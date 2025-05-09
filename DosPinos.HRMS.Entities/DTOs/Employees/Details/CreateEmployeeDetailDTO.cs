namespace DosPinos.HRMS.Entities.DTOs.Employees.Details;

/// <summary>
/// DTO for creating an employee detail.
/// </summary>
public class CreateEmployeeDetailDTO(DateOnly dateBirth,
                                     int children,
                                     byte maritalStatusId,
                                     byte nationalityId,
                                     byte genderId,
                                     byte hiringTypeId,
                                     byte jobTitleId,
                                     string email,
                                     DateOnly entryDate) : EntityDTO, ICreateEmployeeDetailDTO
{
    public DateOnly DateBirth => dateBirth;
    public int Children => children;
    public byte MaritalStatusId => maritalStatusId;
    public byte NationalityId => nationalityId;
    public byte GenderId => genderId;
    public byte HiringTypeId => hiringTypeId;
    public byte JobTitleId => jobTitleId;
    public string Email => email;
    public DateOnly EntryDate => entryDate;
}