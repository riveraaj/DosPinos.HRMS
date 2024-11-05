namespace DosPinos.HRMS.Entities.Interfaces.Employees.Phones
{
    public interface ICreatePhoneDTO
    {
        string PhoneNumber { get; set; }
        byte PhoneTypeId { get; set; }
    }
}