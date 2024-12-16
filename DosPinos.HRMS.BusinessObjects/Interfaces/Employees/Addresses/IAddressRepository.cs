using DosPinos.HRMS.Entities.DTOs.Employees.Addresses;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Addresses
{
    public interface IAddressRepository
    {
        Task<IOperationResponseVO> UpdateAsync(UpdateAddressDTO addressDTO);
    }
}