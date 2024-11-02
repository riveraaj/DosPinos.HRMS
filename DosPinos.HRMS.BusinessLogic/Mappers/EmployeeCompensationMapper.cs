using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Compensations.POCOs;
using DosPinos.HRMS.BusinessObjects.POCOs.Employees.Compensations;
using DosPinos.HRMS.Entities.Interfaces.Employees.Compensations;

namespace DosPinos.HRMS.BusinessLogic.Mappers
{
    internal static class EmployeeCompensationMapper
    {
        public static ICreateEmployeeCompensationPOCO MapFrom(ICreateEmployeeCompensationDTO compensationDTO, int employeeId)
            => new CreateEmployeeCompensationPOCO(employeeId)
            {
                SalaryCategoryId = compensationDTO.SalaryCategoryId,
            };
    }
}