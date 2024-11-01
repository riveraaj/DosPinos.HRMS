namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.PhonesType
{
    public interface IPhoneTypeRepository
    {
        IEnumerable<IGetAllPhoneTypeDTO> GetAll();
    }
}