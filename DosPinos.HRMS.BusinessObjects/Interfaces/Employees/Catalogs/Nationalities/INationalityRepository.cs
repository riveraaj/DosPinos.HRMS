namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Nationalities
{
    public interface INationalityRepository
    {
        IEnumerable<IGetAllNationalityDTO> GetAll();
    }
}