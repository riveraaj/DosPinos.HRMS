using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Phones.POCOs;
using DosPinos.HRMS.BusinessObjects.ValidationAttributes;

namespace DosPinos.HRMS.BusinessObjects.POCOs.Employees.Phones
{
    public class CreatePhonePOCO : ICreatePhonePOCO
    {
        [ValidarPhoneNumber]
        public int PhoneNumber { get; set; }

        [RequiredGreaterThanZero]
        public byte PhoneTypeId { get; set; }
    }
}
