namespace DosPinos.HRMS.Entities.Interfaces.Securities
{
    public interface ILoginUserDTO : IEntityDTO
    {
        int RoleId { get; set; }
        int IdentificationId { get; set; }
        int EmployeeId { get; set; }
        int ManagerId { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        bool Status { get; set; }
    }
}