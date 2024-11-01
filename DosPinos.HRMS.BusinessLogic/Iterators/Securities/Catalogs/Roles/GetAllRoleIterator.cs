namespace DosPinos.HRMS.BusinessLogic.Iterators.Securities.Catalogs.Roles
{
    internal class GetAllRoleIterator(IRoleRepository roleRepository,
                                      ICreateLogIterator createLogIterator,
                                      IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllRoleInputPort
    {
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IOutputPort _outputPort = outputPort;
        public void GetAll(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all roles
                List<IGetAllRoleDTO> roleList = _roleRepository.GetAll().ToList();
                response.Content = roleList;
            }
            catch (Exception exception)
            {
                response = this.HandlerLog(Module.Notification, ActionCategory.Create, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}