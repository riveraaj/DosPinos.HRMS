namespace DosPinos.HRMS.Entities.DTOs.OEEs
{
    public class CreateOEEDTO : EntityDTO, IEntityDTO
    {
        public byte MachineId { get; set; }
        public int EmployeeOne { get; set; }
        public int EmployeeTwo { get; set; }
        public int EmployeeThree { get; set; }
        public decimal OperatingTime { get; set; }
        public decimal RealOperatingTime { get; set; }
    }
}