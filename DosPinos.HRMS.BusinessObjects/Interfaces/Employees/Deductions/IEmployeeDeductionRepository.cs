﻿using DosPinos.HRMS.Entities.DTOs.Employees.Deductions;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Deductions
{
    public interface IEmployeeDeductionRepository
    {
        Task<IEnumerable<GetAllEmployeeDeductionDTO>> GetAllAsync(int employeeId);
        Task<IOperationResponseVO> CreateAsync(UpdateEmployeeDeductionDTO deductionDTO);
        Task<IOperationResponseVO> DeleteAsync(byte deductionId);
    }
}