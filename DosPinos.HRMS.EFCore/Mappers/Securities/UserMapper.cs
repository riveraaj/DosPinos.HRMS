using DosPinos.HRMS.Entities.DTOs.Securities;

namespace DosPinos.HRMS.EFCore.Mappers.Securities
{
    internal static class UserMapper
    {
        public static GetAllUserDTO MapFrom(User user)
            => new()
            {
                FullName = $"{user.Employee.FirstName} {user.Employee.FirstLastName} {user.Employee.SecondLastName}",
                RolId = user.RoleId,
                UserIdDB = user.UserId,
                UserName = user.Username,
                IsActive = user.UserStatus
            };
    }
}