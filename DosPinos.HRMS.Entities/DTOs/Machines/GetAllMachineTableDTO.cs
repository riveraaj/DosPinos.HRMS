namespace DosPinos.HRMS.Entities.DTOs.Machines
{
    public class GetAllMachineTableDTO
    {
        public byte MachineId { get; set; }
        public string Description { get; set; }
        public decimal Production { get; set; }
    }
}