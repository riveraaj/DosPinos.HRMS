namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs
{
    public interface IGetAllPhoneTypeDTO : IEntityDTO
    {
        int PhoneTypeId { get; set; }
        string PhoneTypeDescription { get; set; }
    }
}