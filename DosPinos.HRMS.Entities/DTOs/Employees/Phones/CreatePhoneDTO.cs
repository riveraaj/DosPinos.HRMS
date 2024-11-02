using DosPinos.HRMS.Entities.Interfaces.Employees.Phones;

namespace DosPinos.HRMS.Entities.DTOs.Employees.Phones
{
    public class CreatePhoneDTO : ICreatePhoneDTO
    {
        public int PhoneNumber { get; set; }
        public byte PhoneTypeId { get; set; }
    }
}