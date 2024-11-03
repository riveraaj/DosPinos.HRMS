namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Nationalities
{
    public interface INationalityRepository
    {
        Task<IEnumerable<IGetAllNationalityDTO>> GetAllAsync();
    }
}