namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs
{
    public interface IGetAllSalaryCategoryDTO : IEntityDTO
    {
        int SalaryCategoryId { get; set; }
        string SalaryCategoryDescription { get; set; }
        decimal SalaryCategoryRange { get; set; }
    }
}