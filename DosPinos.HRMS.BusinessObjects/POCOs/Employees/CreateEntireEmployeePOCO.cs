using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Addresses.POCOs;
using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Compensations.POCOs;
using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Deductions.POCOs;
using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Details.POCOs;
using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Phones.POCOs;
using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.POCOs;

namespace DosPinos.HRMS.BusinessObjects.POCOs.Employees
{
    public class CreateEntireEmployeePOCO : ICreateEntireEmployeePOCO
    {
        public ICreateEmployeePOCO Employee { get; set; }
        public ICreateAddressPOCO Address { get; set; }
        public ICreateEmployeeCompensationPOCO Compensation { get; set; }
        public ICreateEmployeeDeductionPOCO Deduction { get; set; }
        public ICreateEmployeeDetailPOCO Detail { get; set; }
        public ICreatePhonePOCO Phone { get; set; }
    }
}