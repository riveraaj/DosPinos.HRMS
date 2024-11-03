namespace DosPinos.HRMS.BusinessObjects.Interfaces.Incapacities.Catalogs.IncapacitiesType.InputPorts
{
    public interface IGetAllIncapacityTypeInputPort
    {
        Task GetAllAsync(IEntityDTO entity);
    }
}