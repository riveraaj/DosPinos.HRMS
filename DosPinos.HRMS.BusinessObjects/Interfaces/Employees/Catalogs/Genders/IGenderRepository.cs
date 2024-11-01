namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Genders
{
    public interface IGenderRepository
    {
        IEnumerable<IGetAllGenderDTO> GetAll();
    }
}