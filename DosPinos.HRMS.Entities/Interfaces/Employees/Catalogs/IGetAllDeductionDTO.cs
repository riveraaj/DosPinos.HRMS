namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs
{
    public interface IGetAllDeductionDTO : IEntityDTO
    {
        int DeductionId { get; set; }
        string DeductionDescription { get; set; }
        decimal DeductionPercentage { get; set; }
    }
}