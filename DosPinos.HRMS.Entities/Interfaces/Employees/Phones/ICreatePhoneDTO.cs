namespace DosPinos.HRMS.Entities.Interfaces.Employees.Phones
{
    public interface ICreatePhoneDTO
    {
        int PhoneNumber { get; set; }
        byte PhoneTypeId { get; set; }
    }
}