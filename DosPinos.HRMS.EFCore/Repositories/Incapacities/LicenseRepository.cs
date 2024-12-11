using DosPinos.HRMS.BusinessObjects.Interfaces.Incapacities;
using DosPinos.HRMS.EFCore.Interfaces;
using DosPinos.HRMS.Entities.DTOs.Incapacities;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;

namespace DosPinos.HRMS.EFCore.Repositories.Incapacities
{
    internal class LicenseRepository(DospinosdbContext context,
                                   IInvokeStoredProcedure invokeSP) : ILicenseRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IOperationResponseVO> CreateAsync(CreateLicenseDTO license)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@dateStart", license.DateStart},
                {"@dateEnd", license.DateEnd},
                {"@documentationPath", license.DocumentationPath},
                {"@employeeId", license.EmployeeId},
                {"@licenseType", license.LicenseTypeId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateLicense", parameters, false);
        }

        public async Task<bool> DeleteAsync(int licenseId)
        {
            License license = await _context.Licenses.FindAsync(licenseId);

            if (license == null) return false;

            _context.Licenses.Remove(license);

            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<IOperationResponseVO> EvaluateAsync(EvaluateLicenseDTO licenseDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@isApproved", licenseDTO.IsApproved},
                {"@employeeId", licenseDTO.EmployeeId},
                {"@licenseId", licenseDTO.LicenseId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateEvaluationLicense", parameters, false);
        }

        public async Task<IEnumerable<GetAllLicenseByEmployeeDTO>> GetAllAsync(int identification)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@identification", identification}
            };

            var result = await _invokeSP.ExecuteAsync("[humanresources].usp_GetAllLicenseByIdentification", parameters, true);

            List<GetAllLicenseByEmployeeDTO> licenseList = [];

            foreach (var row in (List<Dictionary<string, object>>)result.Content)
            {
                licenseList.Add(new GetAllLicenseByEmployeeDTO()
                {
                    EmployeeId = row.TryGetValue("employee_id", out object employeeId) ? Convert.ToInt32(employeeId) : 0,
                    LicenseId = row.TryGetValue("license_id", out object licenseId) ? Convert.ToInt32(licenseId) : 0,
                    TypeLicense = row.TryGetValue("license_type_description", out object typeLicense) ? typeLicense.ToString() : string.Empty,
                    EndDate = row.TryGetValue("date_end", out object endPeriod) && endPeriod != DBNull.Value
                        ? DateOnly.Parse(((DateTime)endPeriod).ToString("yyyy-MM-dd"))
                        : default,
                    StartDate = row.TryGetValue("date_start", out object startPeriod) && startPeriod != DBNull.Value
                        ? DateOnly.Parse(((DateTime)startPeriod).ToString("yyyy-MM-dd"))
                        : default,
                    Days = row.TryGetValue("days", out object days) ? Convert.ToInt32(days) : 0,
                    Status = row.TryGetValue("status", out object status) ? status.ToString() : string.Empty,
                });
            }

            return licenseList;
        }

        public async Task<bool> UpdateAsync(UpdateLicenseDTO licenseDTO)
        {
            License license = await _context.Licenses.FindAsync(licenseDTO.LicenseId);

            if (license == null) return false;

            license.DateStart = licenseDTO.DateStart;
            license.DateEnd = licenseDTO.DateEnd;
            license.DocumentationPath = licenseDTO.DocumentationPath;

            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}