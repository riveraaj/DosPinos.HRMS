using DosPinos.HRMS.Entities.Interfaces.Incapacities.Catalogs;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Incapacities.Catalogs.IncapacitiesType
{
    public interface IIncapacityTypeRepository
    {
        Task<IEnumerable<IGetAllIncapacityTypeDTO>> GetAllAsync();
    }
}