namespace DosPinos.HRMS.Entities.DTOs.Employees
{
    public class UpdateEmployeeDTO : EntityDTO, IEntityDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public decimal Overtime { get; set; }
        public int ManagerId { get; set; }
        public bool HasManager { get; set; }
    }
}