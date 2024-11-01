namespace DosPinos.HRMS.Entities.DTOs.Incapacities.Catalogs
{
    public class GetAllIncapacityTypeDTO : EntityDTO, IGetAllIncapacityTypeDTO
    {
        public int IncapacityTypeId { get; set; }
        public string IncapacityTypeDescription { get; set; }
    }
}