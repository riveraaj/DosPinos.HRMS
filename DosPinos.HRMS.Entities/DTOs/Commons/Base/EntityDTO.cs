namespace DosPinos.HRMS.Entities.DTOs.Commons.Base;

/// <summary>
/// Base class for all DTOs 
/// is used to get the client who do the action.
/// </summary>
public class EntityDTO : IEntityDTO
{
    public int UserId { get; set; }
}