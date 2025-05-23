﻿namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;

/// <summary>
/// Interface for get all phone type.
/// </summary>
public interface IGetAllPhoneTypeDTO : IEntityDTO
{
    int Id { get; }
    string Description { get; }
}