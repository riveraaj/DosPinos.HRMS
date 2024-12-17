using DosPinos.HRMS.BusinessLogic.Services;
using DosPinos.HRMS.Entities.DTOs.Securities;
using DosPinos.HRMS.Entities.Interfaces.Securities;

namespace DosPinos.HRMS.Controllers.Securities
{
    public class UserController(UserService userService)
    {
        private readonly UserService _userService = userService;

        public async Task<IOperationResponseVO> ProcessAsync(ILoginUserDTO userDTO)
            => await _userService.ProcessAsync(userDTO);

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
            => await _userService.GetAllAsync(entity);

        public async Task<IOperationResponseVO> GetAllActiveAsync(IEntityDTO entity)
            => await _userService.GetAllActiveAsync(entity);

        public async Task<IOperationResponseVO> CreateAsync(CreateUserDTO userDTO)
            => await _userService.CreateAsync(userDTO);

        public async Task<IOperationResponseVO> UpdateAsync(UpdateUserDTO userDTO)
            => await _userService.UpdateAsync(userDTO);

        public async Task<IOperationResponseVO> DeleteAsync(DeleteUserDTO userDTO)
            => await _userService.DeleteAsync(userDTO);
    }
}