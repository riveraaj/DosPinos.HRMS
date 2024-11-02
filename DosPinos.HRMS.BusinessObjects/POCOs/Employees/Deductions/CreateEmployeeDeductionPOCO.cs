using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Deductions.POCOs;
using DosPinos.HRMS.BusinessObjects.ValidationAttributes;

namespace DosPinos.HRMS.BusinessObjects.POCOs.Employees.Deductions
{
    public class CreateEmployeeDeductionPOCO : ICreateEmployeeDeductionPOCO
    {
        [RequiredGreaterThanZero]
        public byte DeductionId { get; set; }

        [RequiredGreaterThanZero]
        public int EmployeeId { get; set; }

        [RequiredGreaterThanZero]
        public decimal DeductionAmount { get; set; } = 1;
    }
}