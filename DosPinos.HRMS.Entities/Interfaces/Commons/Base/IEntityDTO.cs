namespace DosPinos.HRMS.Entities.Interfaces.Commons.Base;
/// <summary>
/// Base interface for all DTOs 
/// is used to get the client who do the action.
/// </summary>
public interface IEntityDTO
{
    int UserId { get; set; }
}