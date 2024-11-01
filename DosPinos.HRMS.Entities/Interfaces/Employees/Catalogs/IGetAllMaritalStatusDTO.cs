namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs
{
    public interface IGetAllMaritalStatusDTO : IEntityDTO
    {
        int MaritalStatusId { get; set; }
        string MaritalStatusDescription { get; set; }
    }
}