namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs
{
    public interface IGetAllCantonDTO : IEntityDTO
    {
        int CantonId { get; set; }
        string CantonDescription { get; set; }
        int ProvinceId { get; set; }
    }
}