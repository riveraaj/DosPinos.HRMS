namespace DosPinos.HRMS.BusinessObjects.Interfaces.Permissions.Catalogs.PermissionTypes.InputPorts
{
    public interface IGetAllPermissionTypeInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}