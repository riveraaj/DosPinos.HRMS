namespace DosPinos.HRMS.BusinessObjects.Interfaces.Securities.Catalogs.Roles.InputPorts
{
    public interface IGetAllRoleInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}