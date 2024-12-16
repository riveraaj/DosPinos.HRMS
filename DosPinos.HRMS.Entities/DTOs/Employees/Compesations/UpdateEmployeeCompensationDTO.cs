namespace DosPinos.HRMS.Entities.DTOs.Employees.Compesations
{
    public class UpdateEmployeeCompensationDTO : EntityDTO, IEntityDTO
    {
        public int EmployeeId { get; set; }
        public int SalaryCategoryId { get; set; }
    }
}