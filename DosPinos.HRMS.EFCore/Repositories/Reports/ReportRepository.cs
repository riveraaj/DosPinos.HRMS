using DosPinos.HRMS.BusinessObjects.Interfaces.Reports;
using DosPinos.HRMS.EFCore.Interfaces;
using DosPinos.HRMS.Entities.DTOs.Reports;

namespace DosPinos.HRMS.EFCore.Repositories.Reports
{
    internal class ReportRepository(DospinosdbContext context,
                                   IInvokeStoredProcedure invokeSP) : IReportRepository
    {

        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IEnumerable<LicenseReportDTO>> GetAllLicenseAsync()
        {
            var result = await _invokeSP.ExecuteAsync("[humanresources].usp_GetAllLicenseReport", null, true);

            List<LicenseReportDTO> licenseList = [];

            foreach (var row in (List<Dictionary<string, object>>)result.Content)
            {
                licenseList.Add(new LicenseReportDTO()
                {
                    Identification = row.TryGetValue("identification", out object identification) ? Convert.ToInt32(identification) : 0,
                    FullName = row.TryGetValue("full_name", out object fullName) ? fullName.ToString() : string.Empty,
                    JobTitle = row.TryGetValue("job_title_description", out object jobTitle) ? jobTitle.ToString() : string.Empty,
                    Date = row.TryGetValue("date_end", out object date) && date != DBNull.Value
                        ? DateOnly.Parse(((DateTime)date).ToString("yyyy-MM-dd"))
                        : default,
                    Duration = row.TryGetValue("duration", out object duration) ? Convert.ToInt32(duration) : 0,
                    LicenseType = row.TryGetValue("license_type_description", out object licenseType) ? licenseType.ToString() : string.Empty,
                });
            }

            return licenseList;
        }

        public async Task<IEnumerable<OvertimeReportDTO>> GetAllOvertimeAsync()
        {
            var result = await _invokeSP.ExecuteAsync("[humanresources].usp_GetAllOvertimeReport", null, true);

            List<OvertimeReportDTO> overtimeList = [];

            foreach (var row in (List<Dictionary<string, object>>)result.Content)
            {
                overtimeList.Add(new OvertimeReportDTO()
                {
                    Identification = row.TryGetValue("identification", out object identification) ? Convert.ToInt32(identification) : 0,
                    FullName = row.TryGetValue("full_name", out object fullName) ? fullName.ToString() : string.Empty,
                    JobTitle = row.TryGetValue("job_title_description", out object jobTitle) ? jobTitle.ToString() : string.Empty,
                    Date = row.TryGetValue("actual_date", out object date) && date != DBNull.Value
                        ? DateOnly.Parse(((DateTime)date).ToString("yyyy-MM-dd"))
                        : default,
                    TotalAccrued = row.TryGetValue("total_overtime", out object totalAccrued) ? Convert.ToDecimal(totalAccrued) : 0,
                    Exccess = row.TryGetValue("excess", out object exccess) ? Convert.ToDecimal(exccess) : 0,
                });
            }

            return overtimeList;
        }

        public async Task<IEnumerable<SpecialPermissionReportDTO>> GetAllSpecialPermissionAsync()
        {
            var result = await _invokeSP.ExecuteAsync("[humanresources].usp_GetAllSpecialPermissionReport", null, true);

            List<SpecialPermissionReportDTO> permissionList = [];

            foreach (var row in (List<Dictionary<string, object>>)result.Content)
            {
                permissionList.Add(new SpecialPermissionReportDTO()
                {
                    Identification = row.TryGetValue("identification", out object identification) ? Convert.ToInt32(identification) : 0,
                    FullName = row.TryGetValue("full_name", out object fullName) ? fullName.ToString() : string.Empty,
                    JobTitle = row.TryGetValue("job_title_description", out object jobTitle) ? jobTitle.ToString() : string.Empty,
                    Date = row.TryGetValue("date_end", out object date) && date != DBNull.Value
                        ? DateOnly.Parse(((DateTime)date).ToString("yyyy-MM-dd"))
                        : default,
                    SpecialPermissionType = row.TryGetValue("special_permission_type_description", out object type) ? type.ToString() : string.Empty,
                    Status = row.TryGetValue("status", out object status) ? status.ToString() : string.Empty,
                    Duration = row.TryGetValue("duration", out object duration) ? Convert.ToInt32(duration) : 0,
                });
            }

            return permissionList;
        }

        public async Task<IEnumerable<VacationReportDTO>> GetAllVacationAsync()
        {
            var result = await _invokeSP.ExecuteAsync("[humanresources].usp_GetAllVacationReport", null, true);

            List<VacationReportDTO> vacationList = [];

            foreach (var row in (List<Dictionary<string, object>>)result.Content)
            {
                vacationList.Add(new VacationReportDTO()
                {
                    Identification = row.TryGetValue("identification", out object identification) ? Convert.ToInt32(identification) : 0,
                    FullName = row.TryGetValue("full_name", out object fullName) ? fullName.ToString() : string.Empty,
                    JobTitle = row.TryGetValue("job_title_description", out object jobTitle) ? jobTitle.ToString() : string.Empty,
                    Date = row.TryGetValue("limit_date", out object date) && date != DBNull.Value
                        ? DateOnly.Parse(((DateTime)date).ToString("yyyy-MM-dd"))
                        : default,
                    RemainingDays = row.TryGetValue("remaining_days", out object remainingDays) ? Convert.ToInt32(remainingDays) : 0,
                    UsedDays = row.TryGetValue("used_days", out object usedDays) ? Convert.ToInt32(usedDays) : 0,
                    Status = row.TryGetValue("status", out object status) ? status.ToString() : string.Empty,
                    Total = row.TryGetValue("total_days", out object total) ? Convert.ToInt32(total) : 0,
                });
            }

            return vacationList;
        }
    }
}