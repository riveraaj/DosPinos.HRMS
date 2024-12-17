using DosPinos.HRMS.Entities.DTOs.Commons.Dashboards;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.Dashboards
{
    public interface IDashboardRepository
    {
        Task<IEnumerable<GetAllEmployeesVacationDTO>> GetAllEmployeesVacationAsync();
        Task<GetAllActiveEmployeesDTO> GetAllActiveEmployeesAsync();
        Task<GetAllEmployeesLicenseDTO> GetAllEmployeesLicenseAsync();
        Task<IEnumerable<GetAllCloseVacationDTO>> GetAllCloseVacationAsync();
        Task<IEnumerable<GetAllEmployeesExcessOvertimeDTO>> GetAllEmployeesExcessOvertimeAsync();

    }
}