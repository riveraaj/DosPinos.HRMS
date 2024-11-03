namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Deductions
{
    public interface IDeductionRepository
    {
        Task<IEnumerable<IGetAllDeductionDTO>> GetAllAsync();
    }
}