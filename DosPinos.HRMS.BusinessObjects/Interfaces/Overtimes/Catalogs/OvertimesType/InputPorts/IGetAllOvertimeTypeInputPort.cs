namespace DosPinos.HRMS.BusinessObjects.Interfaces.Overtimes.Catalogs.OvertimesType.InputPorts
{
    public interface IGetAllOvertimeTypeInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}