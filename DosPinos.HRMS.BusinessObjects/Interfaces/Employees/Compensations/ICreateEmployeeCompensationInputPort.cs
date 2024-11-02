using DosPinos.HRMS.Entities.Interfaces.Employees.Compensations;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Compensations
{
    public interface ICreateEmployeeCompensationInputPort
    {
        void Create(ICreateEmployeeCompensationDTO compensationDTO);
    }
}