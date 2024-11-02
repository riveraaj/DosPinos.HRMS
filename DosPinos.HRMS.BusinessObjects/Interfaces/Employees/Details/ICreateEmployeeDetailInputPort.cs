using DosPinos.HRMS.Entities.Interfaces.Employees.Details;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Details
{
    public interface ICreateEmployeeDetailInputPort
    {
        void Create(ICreateEmployeeDetailDTO detailDTO);
    }
}