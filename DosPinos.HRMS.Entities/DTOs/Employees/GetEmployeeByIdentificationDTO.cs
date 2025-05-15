namespace DosPinos.HRMS.Entities.DTOs.Employees;

/// <summary>
/// DTO for retrieving employee information by identification.
/// </summary>
public class GetEmployeeByIdentificationDTO(int id, int identification,
                                            string name, string firstLastName,
                                            string secondLastName, decimal overtimeExcess,
                                            int managerId, DateOnly dateBirth,
                                            int children, string email,
                                            DateOnly dateEntry, int maritalStatusId,
                                            int nationalityId, int genderId,
                                            int hiringTypeId, int jobTitleId,
                                            int salaryCategoryId, decimal vacationRemainingDays,
                                            decimal vacationUsedDays, string address,
                                            int districtId, int cantonId,
                                            int provinceId, string phoneNumber,
                                            int phoneTypeId) : EntityDTO, IGetEmployeeByIdentificationDTO
{
    public int Id => id;
    public int Identification => identification;
    public string Name => name;
    public string FirstLastName => firstLastName;
    public string SecondLastName => secondLastName;
    public decimal OvertimeExcess => overtimeExcess;
    public int ManagerId => managerId;
    public DateOnly DateBirth => dateBirth;
    public int Children => children;
    public string Email => email;
    public DateOnly DateEntry => dateEntry;
    public int MaritalStatusId => maritalStatusId;
    public int NationalityId => nationalityId;
    public int GenderId => genderId;
    public int HiringTypeId => hiringTypeId;
    public int JobTitleId => jobTitleId;
    public int SalaryCategoryId => salaryCategoryId;
    public decimal VacationRemainingDays => vacationRemainingDays;
    public decimal VacationUsedDays => vacationUsedDays;
    public string Address => address;
    public int DistrictId => districtId;
    public int CantonId => cantonId;
    public int ProvinceId => provinceId;
    public string PhoneNumber => phoneNumber;
    public int PhoneTypeId => phoneTypeId;
}