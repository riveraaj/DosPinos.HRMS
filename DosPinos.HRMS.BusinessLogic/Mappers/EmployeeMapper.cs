using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.POCOs;
using DosPinos.HRMS.BusinessObjects.POCOs.Employees;
using DosPinos.HRMS.BusinessObjects.POCOs.Employees.Addresses;
using DosPinos.HRMS.BusinessObjects.POCOs.Employees.Compensations;
using DosPinos.HRMS.BusinessObjects.POCOs.Employees.Details;
using DosPinos.HRMS.BusinessObjects.POCOs.Employees.Phones;
using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.BusinessLogic.Mappers
{
    internal static class EmployeeMapper
    {
        public static ICreateEmployeePOCO MapFrom(ICreateEmployeeDTO employeeDTO)
            => new CreateEmployeePOCO()
            {
                Identification = employeeDTO.Identification,
                Name = employeeDTO.Name,
                FirstLastName = employeeDTO.FirstLastName,
                SecondLastName = employeeDTO.SecondLastName,
                ManagerId = employeeDTO.ManagerId,
            };

        public static ICreateEntireEmployeePOCO MapFrom(ICreateEntireEmployeeDTO employeeDTO)
            => new CreateEntireEmployeePOCO()
            {
                Address = new CreateAddressPOCO()
                {
                    Address = employeeDTO.Address.Address,
                    DistrictId = employeeDTO.Address.DistrictId
                },
                Compensation = new CreateEmployeeCompensationPOCO()
                {
                    SalaryCategoryId = employeeDTO.Compensation.SalaryCategoryId
                },
                Detail = new CreateEmployeeDetailPOCO()
                {
                    Children = employeeDTO.Detail.Children,
                    DateBirth = employeeDTO.Detail.DateBirth,
                    GenderId = employeeDTO.Detail.GenderId,
                    HiringTypeId = employeeDTO.Detail.HiringTypeId,
                    JobTitleId = employeeDTO.Detail.JobTitleId,
                    MaritalStatusId = employeeDTO.Detail.MaritalStatusId,
                    NationalityId = employeeDTO.Detail.NationalityId,
                    Email = employeeDTO.Detail.Email
                },
                Phone = new CreatePhonePOCO()
                {
                    PhoneNumber = employeeDTO.Phone.PhoneNumber,
                    PhoneTypeId = employeeDTO.Phone.PhoneTypeId
                },
                Employee = new CreateEmployeePOCO()
                {
                    FirstLastName = employeeDTO.Employee.FirstLastName,
                    Identification = employeeDTO.Employee.Identification,
                    ManagerId = employeeDTO.Employee.ManagerId,
                    Name = employeeDTO.Employee.Name,
                    SecondLastName = employeeDTO.Employee.SecondLastName,
                    HasManager = employeeDTO.Employee.ManagerId != 0,
                }
            };
    }
}