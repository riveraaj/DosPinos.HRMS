namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Provinces
{
    public interface IProvinceRepository
    {
        IEnumerable<IGetAllProvinceDTO> GetAll();
    }
}