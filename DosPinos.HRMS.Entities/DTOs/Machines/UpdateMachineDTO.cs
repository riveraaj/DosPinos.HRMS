namespace DosPinos.HRMS.Entities.DTOs.Machines
{
    public class UpdateMachineDTO : EntityDTO, IEntityDTO
    {
        public byte MachineId { get; set; }
        public decimal Production { get; set; }
    }
}