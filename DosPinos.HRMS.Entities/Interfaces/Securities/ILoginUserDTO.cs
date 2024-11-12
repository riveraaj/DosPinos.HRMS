namespace DosPinos.HRMS.Entities.Interfaces.Securities
{
    public interface ILoginUserDTO : IEntityDTO
    {
        int RoleId { get; set; }
        int EmployeeId { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
    }
}