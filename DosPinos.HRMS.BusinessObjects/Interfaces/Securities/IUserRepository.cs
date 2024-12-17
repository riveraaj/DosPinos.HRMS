using DosPinos.HRMS.Entities.DTOs.Securities;
using DosPinos.HRMS.Entities.Interfaces.Securities;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Securities
{
    public interface IUserRepository
    {
        Task<ILoginUserDTO> Get(string username);
        Task<IEnumerable<GetAllWithoutUserDTO>> GetAll();
        Task<IEnumerable<GetAllUserDTO>> GetAllActive();
        Task<IOperationResponseVO> CreateAsync(CreateUserDTO userDTO);
        Task<IOperationResponseVO> UpdateAsync(UpdateUserDTO userDTO);
        Task<bool> DeleteAsync(DeleteUserDTO userDTO);
    }
}