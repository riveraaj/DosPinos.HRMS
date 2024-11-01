namespace DosPinos.HRMS.Entities.Interfaces.Incapacities.Catalogs
{
    public interface IGetAllIncapacityTypeDTO : IEntityDTO
    {
        int IncapacityTypeId { get; set; }
        string IncapacityTypeDescription { get; set; }
    }
}