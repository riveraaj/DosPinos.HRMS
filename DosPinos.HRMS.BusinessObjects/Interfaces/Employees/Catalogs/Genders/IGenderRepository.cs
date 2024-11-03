namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Genders
{
    public interface IGenderRepository
    {
        Task<IEnumerable<IGetAllGenderDTO>> GetAllAsync();
    }
}