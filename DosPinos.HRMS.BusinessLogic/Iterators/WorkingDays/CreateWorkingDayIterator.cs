using DosPinos.HRMS.BusinessObjects.Interfaces.WorkingDays;
using DosPinos.HRMS.BusinessObjects.Interfaces.WorkingDays.InputPorts;
using DosPinos.HRMS.Entities.Interfaces.WorkingDays;

namespace DosPinos.HRMS.BusinessLogic.Iterators.WorkingDays
{
    internal class CreateWorkingDayIterator(IWorkingDayRepository workingDayRepository,
                                            ICreateLogIterator createLogIterator,
                                            IOutputPort outputPort) : BaseIterator(createLogIterator), ICreateWorkingDayInputPort
    {
        private readonly IWorkingDayRepository _workingDayRepository = workingDayRepository;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task CreateAsync(IWorkingDayDTO workingDayDTO)
        {
            //IOperationResponseVO response;

            //try
            //{
            //    //Map workingDayDTO

            //}
            //catch (Exception exception)
            //{
            //    response = await this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, workingDayDTO);
            //}

            //_outputPort.Handle(response);
        }
    }
}