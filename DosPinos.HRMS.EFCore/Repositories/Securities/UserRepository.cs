using DosPinos.HRMS.BusinessObjects.Interfaces.Securities;
using DosPinos.HRMS.EFCore.Interfaces;
using DosPinos.HRMS.Entities.DTOs.Securities;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
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

            if (user == null) return null;

            return new LoginUserDTO()
            {
                RoleId = user.RoleId,
                EmployeeId = user.EmployeeId,
                IdentificationId = user.Employee.Identification,
                ManagerId = user.Employee.ManagerId ?? user.EmployeeId,
                Password = user.Password,
                UserName = user.Username,
                Status = user.UserStatus
            };
        }

        public async Task<IEnumerable<GetAllWithoutUserDTO>> GetAll()
        {
            List<GetAllWithoutUserDTO> getAllWithoutUserDTOs = [];

            List<Employee> employeesWithoutUser = await _context.Employees.Where(e => !_context.Users.Any(u => u.EmployeeId == e.EmployeeId))
                                                                          .ToListAsync();

            employeesWithoutUser.ForEach(x =>
            {
                getAllWithoutUserDTOs.Add(new GetAllWithoutUserDTO()
                {
                    EmployeeId = x.EmployeeId,
                    FullName = $"{x.FirstName} {x.FirstLastName} {x.SecondLastName}"
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
    }
}