using DosPinos.HRMS.BusinessObjects.Interfaces.Securities;
using DosPinos.HRMS.EFCore.Mappers.Securities;
using DosPinos.HRMS.Entities.DTOs.Securities;
using DosPinos.HRMS.Entities.Interfaces.Securities;

namespace DosPinos.HRMS.EFCore.Repositories.Securities
{
    internal class UserRepository(DospinosdbContext context,
                                  IInvokeStoredProcedure invokeSP) : IUserRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<ILoginUserDTO> Get(string username)
        {
            User user = await _context.Users.Include(x => x.Employee).FirstOrDefaultAsync(x => x.Username == username);
            int userManagerId = await _context.Users.Where(x => x.EmployeeId == user.Employee.ManagerId)
                                                    .Select(x => x.UserId)
                                                    .FirstOrDefaultAsync();

            if (user == null) return null;

            return new LoginUserDTO()
            {
                RoleId = user.RoleId,
                EmployeeId = user.EmployeeId,
                IdentificationId = user.Employee.Identification,
                ManagerId = (userManagerId != 0) ? userManagerId : user.UserId,
                Password = user.Password,
                UserName = user.Username,
                Status = user.UserStatus,
                UserId = user.UserId,
            };
        }

        public async Task<IEnumerable<GetAllWithoutUserDTO>> GetAll()
        {
            List<GetAllWithoutUserDTO> getAllWithoutUserDTOs = [];

            List<Employee> employeesWithoutUser = await _context.Employees.Include(x => x.EmployeeDetails)
                                                                            .ThenInclude(x => x.JobTitle)
                                                                          .Where(e => !_context.Users.Any(u => u.EmployeeId == e.EmployeeId) && e.EmployeeStatus)
                                                                          .ToListAsync();

            employeesWithoutUser.ForEach(x =>
            {
                getAllWithoutUserDTOs.Add(new GetAllWithoutUserDTO()
                {
                    EmployeeId = x.EmployeeId,
                    FullName = $"{x.Identification} | {x.FirstName} {x.FirstLastName} {x.SecondLastName} | {x.EmployeeDetails.FirstOrDefault().JobTitle.JobTitleDescription}"
                });
            });

            return getAllWithoutUserDTOs;
        }

        public async Task<IOperationResponseVO> CreateAsync(CreateUserDTO userDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@username", userDTO.Username},
                {"@password", userDTO.Password},
                {"@employeeId", userDTO.EmployeeId},
                {"@roleId", userDTO.RoleId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateUser", parameters, false);
        }

        public async Task<IEnumerable<GetAllUserDTO>> GetAllActive()
        {
            List<User> users = [.. await _context.Users.Include(x => x.Employee).Where(x => x.UserId != 1).ToListAsync()];
            return users.Select(UserMapper.MapFrom).ToList();
        }

        public async Task<IOperationResponseVO> UpdateAsync(UpdateUserDTO userDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@userId", userDTO.UserIdDB},
                {"@roleId", userDTO.RoleId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_UpdateUser", parameters, false);
        }

        public async Task<bool> DeleteAsync(DeleteUserDTO userDTO)
        {
            User user = await _context.Users.FindAsync(userDTO.UserIdDB);

            if (user == null) return false;

            user.UserStatus = userDTO.IsActive;

            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}