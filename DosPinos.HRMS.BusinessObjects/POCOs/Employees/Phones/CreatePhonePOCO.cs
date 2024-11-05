using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Phones.POCOs;
using DosPinos.HRMS.BusinessObjects.ValidationAttributes;

namespace DosPinos.HRMS.BusinessObjects.POCOs.Employees.Phones
{
    public class CreatePhonePOCO : ICreatePhonePOCO
    {
        [RequiredAndMaxLength(20)]
        public string PhoneNumber { get; set; }

        [RequiredGreaterThanZero]
        public byte PhoneTypeId { get; set; }
    }
}
