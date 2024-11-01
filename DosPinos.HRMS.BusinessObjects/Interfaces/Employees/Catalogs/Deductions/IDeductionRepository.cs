namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.Deductions
{
    public interface IDeductionRepository
    {
        IEnumerable<IGetAllDeductionDTO> GetAll();
    }
}