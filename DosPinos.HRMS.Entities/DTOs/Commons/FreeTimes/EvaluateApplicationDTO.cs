namespace DosPinos.HRMS.Entities.DTOs.Commons.FreeTimes;

/// <summary>
/// DTO for evaluate applications 
/// like: vacation, licenses & permissions.
/// </summary>
public class EvaluateApplicationDTO(int id, int employeeId,
                                    bool isApproved,
                                    ApplicationCode code) : EntityDTO, IEvaluateApplicationDTO
{
    public int Id => id;
    public int EmployeeId => employeeId;
    public bool IsApproved => isApproved;
    public ApplicationCode Code => code;
}