using DosPinos.HRMS.Entities.Interfaces.Employees;

namespace DosPinos.HRMS.Entities.DTOs.Employees
{
    public class CreateEmployeeDTO : EntityDTO, ICreateEmployeeDTO
    {
        public int Identification { get; set; }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public int ManagerId { get; set; }
    }
}