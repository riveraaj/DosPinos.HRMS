using DosPinos.HRMS.Entities.Interfaces.WorkingDays;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.WorkingDays.InputPorts
{
    public interface ICreateWorkingDayInputPort
    {
        Task CreateAsync(IWorkingDayDTO workingDayDTO);
    }
}