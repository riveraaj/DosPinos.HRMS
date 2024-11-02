using DosPinos.HRMS.Entities.Interfaces.Employees.Addresses;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Addresses
{
    public interface ICreateAddressInputPort
    {
        void Create(ICreateAddressDTO addressDTO);
    }
}