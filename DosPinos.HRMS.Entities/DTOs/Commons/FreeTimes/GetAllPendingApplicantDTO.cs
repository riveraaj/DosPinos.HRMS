namespace DosPinos.HRMS.Entities.DTOs.Commons.FreeTimes;

/// <summary>
/// DTO for get all pending application to resolve.
/// </summary>
public class GetAllPendingApplicantDTO(int id, ApplicationCode code,
                                       string employeeName, string jobTitle,
                                       DateOnly startDate, DateOnly endDate,
                                       int days, string applicationType,
                                       string documentPath) : EntityDTO, IGetAllPendingApplicationDTO
{
    public int Id => id;
    public ApplicationCode Code => code;
    public string EmployeeName => employeeName;
    public string JobTitle => jobTitle;
    public DateOnly StartDate => startDate;
    public DateOnly EndDate => endDate;
    public int Days => days;
    public string ApplicationType => applicationType;
    public string DocumentPath => documentPath;
}