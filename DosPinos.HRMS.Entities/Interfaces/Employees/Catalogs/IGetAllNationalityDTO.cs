namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs
{
    public interface IGetAllNationalityDTO : IEntityDTO
    {
        int NationalityId { get; set; }
        string NationalityDescription { get; set; }
    }
}