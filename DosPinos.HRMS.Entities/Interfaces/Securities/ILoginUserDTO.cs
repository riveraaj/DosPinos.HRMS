namespace DosPinos.HRMS.Entities.Interfaces.Securities
{
    public interface ILoginUserDTO : IEntityDTO
    {
        string UserName { get; set; }
        string Password { get; set; }
    }
}