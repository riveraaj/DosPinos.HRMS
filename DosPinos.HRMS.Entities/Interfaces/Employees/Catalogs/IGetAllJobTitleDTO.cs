namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs
{
    public interface IGetAllJobTitleDTO : IEntityDTO
    {
        int JobTitleId { get; set; }
        string JobTitleDescription { get; set; }
    }
}