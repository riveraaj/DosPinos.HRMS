﻿using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.SalaryCategories;

namespace DosPinos.HRMS.Controllers.SalaryCategories
{
    public class SalaryCategoryController(SalaryCategoryService service)
    {
        private readonly SalaryCategoryService _service = service;

        public async Task<IOperationResponseVO> CreateASync(CreateSalaryCategoryDTO saalryCategoryDTO)
            => await _service.CreateASync(saalryCategoryDTO);


        public async Task<IOperationResponseVO> DeleteAsync(byte saalryCategoryId, IEntityDTO entity)
            => await _service.DeleteAsync(saalryCategoryId, entity);
    }
}