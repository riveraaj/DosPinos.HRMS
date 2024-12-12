namespace DosPinos.HRMS.BusinessObjects.Interfaces.Licenses.Catalogs.LicenseTypes.InputPorts
{
    public interface IGetAllLicenseTypeInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}