namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.PhonesType
{
    public interface IPhoneTypeRepository
    {
        Task<IEnumerable<IGetAllPhoneTypeDTO>> GetAllAsync();
    }
}