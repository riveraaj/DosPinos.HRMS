namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs;

/// <summary>
/// DTO for get all phone type.
/// </summary>
public class GetAllPhoneTypeDTO(int id,
                                string description) : EntityDTO, IGetAllPhoneTypeDTO
{
    public int Id => id;
    public string Description => description;
}