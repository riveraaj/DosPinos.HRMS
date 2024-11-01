namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.HiringsType
{
    public interface IHiringTypeRepository
    {
        IEnumerable<IGetAllHiringTypeDTO> GetAll();
    }
}