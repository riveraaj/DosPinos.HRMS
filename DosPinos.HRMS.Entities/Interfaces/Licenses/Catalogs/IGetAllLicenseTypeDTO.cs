namespace DosPinos.HRMS.Entities.Interfaces.Licenses.Catalogs
{
    public interface IGetAllLicenseTypeDTO : IEntityDTO
    {
        int LicenseTypeId { get; set; }
        string LicenseTypeDescription { get; set; }
    }
}