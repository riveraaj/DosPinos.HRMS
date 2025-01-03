﻿using DosPinos.HRMS.Entities.Interfaces.Overtimes.Catalogs;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Overtimes.Catalogs.OvertimesType
{
    public interface IOvertimeTypeRepository
    {
        Task<IEnumerable<IGetAllOvertimeTypeDTO>> GetAllAsync();
    }
}