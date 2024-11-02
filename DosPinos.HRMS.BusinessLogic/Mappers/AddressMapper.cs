using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Addresses.POCOs;
using DosPinos.HRMS.BusinessObjects.POCOs.Employees.Addresses;
using DosPinos.HRMS.Entities.Interfaces.Employees.Addresses;

namespace DosPinos.HRMS.BusinessLogic.Mappers
{
    internal static class AddressMapper
    {
        public static ICreateAddressPOCO MapFrom(ICreateAddressDTO addressDTO, int employeeId)
            => new CreateAddressPOCO(employeeId)
            {
                Address = addressDTO.Address,
                DistrictId = addressDTO.DistrictId,
            };
    }
}