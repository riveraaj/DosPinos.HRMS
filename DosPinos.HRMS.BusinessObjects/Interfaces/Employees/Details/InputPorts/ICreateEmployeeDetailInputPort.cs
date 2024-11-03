using DosPinos.HRMS.Entities.Interfaces.Employees.Details;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Details.InputPorts
{
    public interface ICreateEmployeeDetailInputPort
    {
        Task CreateAsync(ICreateEmployeeDetailDTO detailDTO);
    }
}