namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Phones.POCOs
{
    public interface ICreatePhonePOCO
    {
        int PhoneNumber { get; set; }
        byte PhoneTypeId { get; set; }
        int EmployeeId { get; }
    }
}