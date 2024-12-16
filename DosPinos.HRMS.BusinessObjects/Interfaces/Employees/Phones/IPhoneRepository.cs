using DosPinos.HRMS.Entities.DTOs.Employees.Phones;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Phones
{
    public interface IPhoneRepository
    {
        Task<IOperationResponseVO> UpdateAsync(UpdatePhoneDTO phoneDTO);
    }
}