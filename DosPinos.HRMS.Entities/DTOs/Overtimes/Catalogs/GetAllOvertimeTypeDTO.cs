namespace DosPinos.HRMS.Entities.DTOs.Overtimes.Catalogs
{
    public class GetAllOvertimeTypeDTO : EntityDTO, IGetAllOvertimeTypeDTO
    {
        public int OvertimeTypeId { get; set; }
        public string OvertimeTypeDescription { get; set; }
        public decimal Multiplier { get; set; }
    }
}