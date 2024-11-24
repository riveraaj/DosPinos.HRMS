using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Addresses.POCOs;
using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Compensations.POCOs;
using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Details.POCOs;
using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Phones.POCOs;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.POCOs
{
    public interface ICreateEntireEmployeePOCO
    {
        ICreateEmployeePOCO Employee { get; set; }
        ICreateAddressPOCO Address { get; set; }
        ICreateEmployeeCompensationPOCO Compensation { get; set; }
        ICreateEmployeeDetailPOCO Detail { get; set; }
        ICreatePhonePOCO Phone { get; set; }
    }
}