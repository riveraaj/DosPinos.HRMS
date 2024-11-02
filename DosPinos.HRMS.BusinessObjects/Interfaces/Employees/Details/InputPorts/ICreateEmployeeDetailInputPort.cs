using DosPinos.HRMS.Entities.Interfaces.Employees.Details;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Details.InputPorts
{
    public interface ICreateEmployeeDetailInputPort
    {
        void Create(ICreateEmployeeDetailDTO detailDTO);
    }
}