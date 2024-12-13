using DosPinos.HRMS.BusinessObjects.Interfaces.Commons.FreeTimes;
using DosPinos.HRMS.Entities.DTOs.Commons.FreeTimes;
using DosPinos.HRMS.Entities.Enums.FreeTimes;

namespace DosPinos.HRMS.EFCore.Repositories.Commons.FreeTimes
{
    internal class FreeTimeRepository(DospinosdbContext context,
                                   IInvokeStoredProcedure invokeSP) : IFreeTimeRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IEnumerable<GetAllPendingApplicantDTO>> GetAllAsync()
        {
            var result = await _invokeSP.ExecuteAsync("[humanresources].ups_GetAllPendingApplicant", null, true);

            List<GetAllPendingApplicantDTO> applicantList = [];

            foreach (var row in (List<Dictionary<string, object>>)result.Content)
            {
                applicantList.Add(new GetAllPendingApplicantDTO()
                {
                    ApplicantId = row.TryGetValue("applicant_id", out object applicantId) ? Convert.ToInt32(applicantId) : 0,
                    Code = row.TryGetValue("code", out object code) ? (ApplicationCode)code : 0,
                    EmployeeName = row.TryGetValue("full_name", out object fullName) ? fullName.ToString() : string.Empty,
                    JobTitle = row.TryGetValue("job_title_description", out object jobTitle) ? jobTitle.ToString() : string.Empty,
                    StartDate = row.TryGetValue("date_start", out object startDate) && startDate != DBNull.Value
                        ? DateOnly.Parse(((DateTime)startDate).ToString("yyyy-MM-dd"))
                        : default,
                    EndDate = row.TryGetValue("date_end", out object endDate) && endDate != DBNull.Value
                        ? DateOnly.Parse(((DateTime)endDate).ToString("yyyy-MM-dd"))
                        : default,
                    Days = row.TryGetValue("days", out object days) ? Convert.ToInt32(days) : 0,
                    ApplicationType = row.TryGetValue("applicant_type", out object applicationType) ? applicationType.ToString() : string.Empty,
                    DocumentationPath = row.TryGetValue("documentation_path", out object path) ? path.ToString() : string.Empty,
                });
            }

            return applicantList;
        }
    }
}