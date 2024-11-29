using DosPinos.HRMS.Entities.DTOs.Reports;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Reports
{
    public interface IReportRepository
    {
        Task<IEnumerable<SpecialPermissionReportDTO>> GetAllSpecialPermissionAsync();
        Task<IEnumerable<VacationReportDTO>> GetAllVacationAsync();
        Task<IEnumerable<OvertimeReportDTO>> GetAllOvertimeAsync();
        Task<IEnumerable<LicenseReportDTO>> GetAllLicenseAsync();
    }
}