namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.JobsTitle
{
    public interface IJobTitleRepository
    {
        Task<IEnumerable<IGetAllJobTitleDTO>> GetAllAsync();
    }
}