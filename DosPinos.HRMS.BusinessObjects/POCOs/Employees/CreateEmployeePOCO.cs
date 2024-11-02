using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.POCOs;
using DosPinos.HRMS.BusinessObjects.ValidationAttributes;

namespace DosPinos.HRMS.BusinessObjects.POCOs.Employees
{
    public class CreateEmployeePOCO : ICreateEmployeePOCO
    {
        [Range(1, int.MaxValue, ErrorMessage = "El campo es requerido")]
        [IdentificationCostaRica]
        public int Identification { get; set; }

        [RequiredAndMaxLength(50)]
        public string Name { get; set; }

        [RequiredAndMaxLength(50)]
        public string FirstLastName { get; set; }

        [RequiredAndMaxLength(50)]
        public string SecondLastName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El campo es requerido")]
        public int ManagerId { get; set; }
    }
}