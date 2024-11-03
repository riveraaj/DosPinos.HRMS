using DosPinos.HRMS.Entities.Interfaces.Employees.Phones;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Phones.InputPorts
{
    public interface ICreatePhoneInputPort
    {
        Task CreateAsync(ICreatePhoneDTO phoneDTO);
    }
}