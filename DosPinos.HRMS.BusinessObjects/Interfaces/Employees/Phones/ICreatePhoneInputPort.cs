using DosPinos.HRMS.Entities.Interfaces.Employees.Phones;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Phones
{
    public interface ICreatePhoneInputPort
    {
        void Create(ICreatePhoneDTO phoneDTO);
    }
}