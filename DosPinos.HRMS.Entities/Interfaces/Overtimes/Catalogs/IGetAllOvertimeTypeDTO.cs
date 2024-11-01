namespace DosPinos.HRMS.Entities.Interfaces.Overtimes.Catalogs
{
    public interface IGetAllOvertimeTypeDTO : IEntityDTO
    {
        int OvertimeTypeId { get; set; }
        string OvertimeTypeDescription { get; set; }
        decimal Multiplier { get; set; }
    }
}