using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Compensations.POCOs;
using DosPinos.HRMS.BusinessObjects.ValidationAttributes;

namespace DosPinos.HRMS.BusinessObjects.POCOs.Employees.Compensations
{
    public class CreateEmployeeCompensationPOCO : ICreateEmployeeCompensationPOCO
    {
        [RequiredGreaterThanZero]
        public byte SalaryCategoryId { get; set; }
    }
}