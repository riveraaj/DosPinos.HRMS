namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Districts
{
    public interface IDistrictRepository
    {
        Task<IEnumerable<IGetAllDistrictDTO>> GetAllAsync();
    }
}