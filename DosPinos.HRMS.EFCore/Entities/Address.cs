namespace DosPinos.HRMS.EFCore.Entities;

public partial class Address
{
    public int AddressId { get; set; }

    public string HousingAddress { get; set; }

    public short DistrictId { get; set; }

    public int EmployeeId { get; set; }

    public virtual District District { get; set; }

    public virtual Employee Employee { get; set; }
}
