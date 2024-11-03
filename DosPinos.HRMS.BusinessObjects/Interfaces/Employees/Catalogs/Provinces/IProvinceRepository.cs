namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Provinces
{
    public interface IProvinceRepository
    {
        Task<IEnumerable<IGetAllProvinceDTO>> GetAllAsync();
    }
}