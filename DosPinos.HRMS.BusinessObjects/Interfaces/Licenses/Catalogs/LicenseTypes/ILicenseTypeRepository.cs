using DosPinos.HRMS.Entities.Interfaces.Licenses.Catalogs;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Licenses.Catalogs.LicenseTypes
{
    public interface ILicenseTypeRepository
    {
        Task<IEnumerable<IGetAllLicenseTypeDTO>> GetAllAsync();
    }
}