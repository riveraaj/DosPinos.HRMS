using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.POCOs;

namespace DosPinos.HRMS.BusinessObjects.POCOs.Employees
{
    public class CreateEmployeePOCO : ICreateEmployeePOCO
    {
        [IdentificationCostaRica]
        public int Identification { get; set; }

        [RequiredAndMaxLength(50)]
        public string Name { get; set; }

        [RequiredAndMaxLength(50)]
        public string FirstLastName { get; set; }

        [RequiredAndMaxLength(50)]
        public string SecondLastName { get; set; }

        public int ManagerId { get; set; }

        public bool HasManager { get; set; }

    }
}