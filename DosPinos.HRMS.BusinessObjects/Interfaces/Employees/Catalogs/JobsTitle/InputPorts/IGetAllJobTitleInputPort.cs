namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.JobsTitle.InputPorts
{
    public interface IGetAllJobTitleInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}