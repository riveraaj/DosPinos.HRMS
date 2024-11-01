namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Districts
{
    public interface IDistrictRepository
    {
        IEnumerable<IGetAllDistrictDTO> GetAll();
    }
}