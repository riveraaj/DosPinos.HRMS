using DosPinos.HRMS.Entities.Interfaces.Employees.Compensations;

namespace DosPinos.HRMS.Entities.DTOs.Employees.Compesations
{
    public class CreateEmployeeCompensationDTO : ICreateEmployeeCompensationDTO
    {
        public byte SalaryCategoryId { get; set; }
    }
}