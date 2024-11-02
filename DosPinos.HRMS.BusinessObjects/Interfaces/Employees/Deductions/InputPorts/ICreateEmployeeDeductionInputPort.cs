using DosPinos.HRMS.Entities.Interfaces.Employees.Deductions;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Deductions.InputPorts
{
    public interface ICreateEmployeeDeductionInputPort
    {
        void Create(ICreateEmployeeDeductionDTO deductionDTO);
    }
}