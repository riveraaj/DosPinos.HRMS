namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs
{
    public interface IGetAllIncomeTaxDTO : IEntityDTO
    {
        int IncomeTaxId { get; set; }
        decimal IncomeTaxPercentage { get; set; }
    }
}