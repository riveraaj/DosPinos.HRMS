namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs
{
    public interface IGetAllHiringTypeDTO : IEntityDTO
    {
        int HiringTypeId { get; set; }
        string HiringTypeDescription { get; set; }
    }
}