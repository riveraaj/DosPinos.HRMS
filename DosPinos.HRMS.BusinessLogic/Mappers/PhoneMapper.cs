using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Phones.POCOs;
using DosPinos.HRMS.BusinessObjects.POCOs.Employees.Phones;
using DosPinos.HRMS.Entities.Interfaces.Employees.Phones;

namespace DosPinos.HRMS.BusinessLogic.Mappers
{
    internal static class PhoneMapper
    {
        public static ICreatePhonePOCO MapFrom(ICreatePhoneDTO phoneDTO, int employeeId)
            => new CreatePhonePOCO(employeeId)
            {
                PhoneNumber = phoneDTO.PhoneNumber,
                PhoneTypeId = phoneDTO.PhoneTypeId,
            };
    }
}