﻿using DosPinos.HRMS.BusinessObjects.Interfaces.Employees;
using DosPinos.HRMS.Entities.DTOs.Employees;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class EmployeeService(IEmployeeRepository employeeRepository,
                                 ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        public async Task<IOperationResponseVO> GetAsync(int identification, IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get employee
                var employee = await _employeeRepository.GetAsync(identification);

                if (employee == null) return this.CustomWarning("Lo sentimos, no se ha podido encontrar al empleado.");

                response.Content = employee;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Get, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> GetAllActiveAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = await _employeeRepository.GetAllActiveAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all manager
                response.Content = await _employeeRepository.GetAllManagerAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> UpdateAsync(UpdateEmployeeDTO employeeDTO)
        {
            IOperationResponseVO response;
            try
            {
                employeeDTO.HasManager = employeeDTO.ManagerId != 0;
                response = await _employeeRepository.UpdateAsync(employeeDTO);
                if (response.Status == ResponseStatus.Error) throw new Exception(response.Message.FirstOrDefault());
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Update, exception, employeeDTO);
            }

            return response;
        }
    }
}