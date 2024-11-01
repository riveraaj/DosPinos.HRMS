namespace DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs
{
    public interface IGetAllGenderDTO : IEntityDTO
    {
        int GenderId { get; set; }
        string GenderDescription { get; set; }
    }
}