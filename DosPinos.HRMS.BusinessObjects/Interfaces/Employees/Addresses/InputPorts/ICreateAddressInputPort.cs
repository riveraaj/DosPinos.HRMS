﻿using DosPinos.HRMS.Entities.Interfaces.Employees.Addresses;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Addresses.InputPorts
{
    public interface ICreateAddressInputPort
    {
        Task CreateAsync(ICreateAddressDTO addressDTO);
    }
}