namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.JobsTitle
{
    public interface IJobTitleRepository
    {
        IEnumerable<IGetAllJobTitleDTO> GetAll();
    }
}