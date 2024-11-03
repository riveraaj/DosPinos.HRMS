namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Cantons
{
    public interface ICantonRepository
    {
        Task<IEnumerable<IGetAllCantonDTO>> GetAllAsync();
    }
}