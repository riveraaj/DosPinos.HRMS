namespace DosPinos.HRMS.Entities.DTOs.Employees.Phones
{
    public class CreatePhoneDTO : ICreatePhoneDTO
    {
        public string PhoneNumber { get; set; }
        public byte PhoneTypeId { get; set; }
    }
}