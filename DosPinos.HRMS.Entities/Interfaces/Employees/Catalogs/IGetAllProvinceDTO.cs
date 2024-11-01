namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs
{
    public interface IGetAllProvinceDTO : IEntityDTO
    {
        int ProvinceId { get; set; }
        string ProvinceDescription { get; set; }
    }
}