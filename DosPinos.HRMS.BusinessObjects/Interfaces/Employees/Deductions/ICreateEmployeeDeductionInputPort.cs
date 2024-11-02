using DosPinos.HRMS.Entities.Interfaces.Employees.Deductions;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Deductions
{
    public interface ICreateEmployeeDeductionInputPort
    {
        void Create(ICreateEmployeeDeductionDTO deductionDTO);
    }
}