namespace DosPinos.HRMS.BusinessLogic.Iterators.Securities.Catalogs.Roles
{
    internal class GetAllRoleIterator(IRoleRepository roleRepository,
                                      ICreateLogIterator createLogIterator,
                                      IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllRoleInputPort
    {
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public async Task GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all roles
                IEnumerable<IGetAllRoleDTO> roleList = await _roleRepository.GetAllAsync();
                response.Content = roleList;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}