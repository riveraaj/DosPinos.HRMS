using DosPinos.HRMS.Entities.Interfaces.Licenses.Catalogs;

namespace DosPinos.HRMS.Entities.DTOs.Licenses.Catalogs
{
    public class GetAllLicenseTypeDTO : EntityDTO, IGetAllLicenseTypeDTO
    {
        public int LicenseTypeId { get; set; }
        public string LicenseTypeDescription { get; set; }
    }
}