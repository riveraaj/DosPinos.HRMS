namespace DosPinos.HRMS.Entities.Interfaces.Employees;

/// <summary>
/// Interface for retrieving employee information by identification.
/// </summary>
public interface IGetEmployeeByIdentificationDTO : IEntityDTO
{
    public int Id { get; }
    public int Identification { get; }
    public string Name { get; }
    public string FirstLastName { get; }
    public string SecondLastName { get; }
    public decimal OvertimeExcess { get; }
    public int ManagerId { get; }
    public DateOnly DateBirth { get; }
    public int Children { get; }
    public string Email { get; }
    public DateOnly DateEntry { get; }
    public int MaritalStatusId { get; }
    public int NationalityId { get; }
    public int GenderId { get; }
    public int HiringTypeId { get; }
    public int JobTitleId { get; }
    public int SalaryCategoryId { get; }
    public decimal VacationRemainingDays { get; }
    public decimal VacationUsedDays { get; }
    public string Address { get; }
    public int DistrictId { get; }
    public int CantonId { get; }
    public int ProvinceId { get; }
    public string PhoneNumber { get; }
    public int PhoneTypeId { get; }
}