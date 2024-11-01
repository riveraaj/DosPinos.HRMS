namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs
{
    public interface IGetAllDistrictDTO : IEntityDTO
    {
        int DistrictId { get; set; }
        string DistrictDescription { get; set; }
        int CantonId { get; set; }
    }
}