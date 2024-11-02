using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Deductions.POCOs;
using DosPinos.HRMS.BusinessObjects.POCOs.Employees.Deductions;
using DosPinos.HRMS.Entities.Interfaces.Employees.Deductions;

namespace DosPinos.HRMS.BusinessLogic.Mappers
{
    internal static class EmployeeDeductionMapper
    {
        public static ICreateEmployeeDeductionPOCO MapFrom(ICreateEmployeeDeductionDTO deductionDTO, int employeeId)
            => new CreateEmployeeDeductionPOCO
            {
                DeductionAmount = deductionDTO.DeductionAmount,
                DeductionId = deductionDTO.DeductionId,
                EmployeeId = employeeId
            };
    }
}