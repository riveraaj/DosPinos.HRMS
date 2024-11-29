namespace DosPinos.HRMS.Entities.DTOs.Employees
{
    public class GetEmployeeByIdentifactionDTO
    {
        public int EmployeeId { get; set; }
        public int Identification { get; set; }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public decimal OvertimeExcess { get; set; }
        public int ManagerId { get; set; }
        public DateOnly DateBirth { get; set; }
        public int Children { get; set; }
        public string Email { get; set; }
        public DateOnly DateEntry { get; set; }
        public int MaritalStatusId { get; set; }
        public int NationalityId { get; set; }
        public int GenderId { get; set; }
        public int HiringTypeId { get; set; }
        public int JobTitleId { get; set; }
        public int SalaryCategoryId { get; set; }
        public decimal VacationRemainingDays { get; set; }
        public decimal VacationUsedDays { get; set; }
        public string Address { get; set; }
        public int DistrictId { get; set; }
        public int CantonId { get; set; }
        public int ProvinceId { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneTypeId { get; set; }
    }
}