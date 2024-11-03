namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Addresses.POCOs
{
    public interface ICreateAddressPOCO
    {
        string Address { get; set; }
        short DistrictId { get; set; }
    }
}