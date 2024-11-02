using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Compensations.POCOs;

namespace DosPinos.HRMS.BusinessObjects.POCOs.Employees.Compensations
{
    public class CreateEmployeeCompensationPOCO(int employeeId) : ICreateEmployeeCompensationPOCO
    {
        [Range(1, int.MaxValue, ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Resources.Commons.Commons))]
        public byte SalaryCategoryId { get; set; }

        [Range(1, int.MaxValue, ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Resources.Commons.Commons))]
        public int EmployeeId { get; } = employeeId;
    }
}