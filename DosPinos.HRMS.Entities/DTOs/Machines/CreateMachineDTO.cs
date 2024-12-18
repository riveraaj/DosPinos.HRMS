namespace DosPinos.HRMS.Entities.DTOs.Machines
{
    public class CreateMachineDTO : EntityDTO, IEntityDTO
    {
        public string Description { get; set; }
        public decimal MachineProduction { get; set; }
    }
}