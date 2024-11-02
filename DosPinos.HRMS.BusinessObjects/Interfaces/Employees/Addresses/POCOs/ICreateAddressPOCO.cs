namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Addresses.POCOs
{
    public interface ICreateAddressPOCO
    {
        string Address { get; set; }
        byte DistrictId { get; set; }
        int EmployeeId { get; }
    }
}