﻿using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.Employees.Deductions;

namespace DosPinos.HRMS.Controllers.Employees
{
    public class EmployeeDeductionController(EmployeeDeductionService service)
    {
        private readonly EmployeeDeductionService _service = service;

        public async Task<IOperationResponseVO> GetAllAsync(int employeeId, IEntityDTO entity)
            => await _service.GetAllAsync(employeeId, entity);

        public async Task<IOperationResponseVO> CreateAsync(CreateEmployeeDeductionDTO deductionDTO)
            => await _service.CreateASync(deductionDTO);

        public async Task<IOperationResponseVO> DeleteAsync(int deductionID, IEntityDTO entity)
            => await _service.DeleteAsync(deductionID, entity);
    }
}