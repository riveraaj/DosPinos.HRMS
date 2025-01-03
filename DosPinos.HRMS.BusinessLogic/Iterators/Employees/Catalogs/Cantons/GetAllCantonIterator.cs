﻿namespace DosPinos.HRMS.BusinessLogic.Iterators.Employees.Catalogs.Cantons
{
    internal class GetAllCantonIterator(ICantonRepository cantonRepository,
                                        ICreateLogIterator createLogIterator,
                                        IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllCantonInputPort
    {
        private readonly ICantonRepository _cantonRepository = cantonRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public async Task GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all cantons
                IEnumerable<IGetAllCantonDTO> cantonList = await _cantonRepository.GetAllAsync();
                response.Content = cantonList;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}