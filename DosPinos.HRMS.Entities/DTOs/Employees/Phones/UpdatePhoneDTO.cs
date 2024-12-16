namespace DosPinos.HRMS.Entities.DTOs.Employees.Phones
{
    public class UpdatePhoneDTO : EntityDTO, IEntityDTO
    {
        public int EmployeeId { get; set; }
        public string Number { get; set; }
        public int PhoneTypeId { get; set; }
    }
}