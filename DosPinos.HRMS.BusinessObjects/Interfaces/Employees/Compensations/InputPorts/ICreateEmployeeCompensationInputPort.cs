﻿using DosPinos.HRMS.Entities.Interfaces.Employees.Compensations;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Compensations.InputPorts
{
    public interface ICreateEmployeeCompensationInputPort
    {
        Task CreateAsync(ICreateEmployeeCompensationDTO compensationDTO);
    }
}