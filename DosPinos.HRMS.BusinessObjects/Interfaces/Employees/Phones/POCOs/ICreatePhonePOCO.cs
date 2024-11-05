namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Phones.POCOs
{
    public interface ICreatePhonePOCO
    {
        string PhoneNumber { get; set; }
        byte PhoneTypeId { get; set; }
    }
}