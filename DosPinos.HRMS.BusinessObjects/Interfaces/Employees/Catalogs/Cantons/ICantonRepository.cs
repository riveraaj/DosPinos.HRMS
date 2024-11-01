namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Cantons
{
    public interface ICantonRepository
    {
        IEnumerable<IGetAllCantonDTO> GetAll();
    }
}