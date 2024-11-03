namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.HiringsType
{
    public interface IHiringTypeRepository
    {
        Task<IEnumerable<IGetAllHiringTypeDTO>> GetAllAsync();
    }
}