using DosPinos.HRMS.BusinessObjects.Interfaces.Permissions.Catalogs.PermissionTypes;
using DosPinos.HRMS.BusinessObjects.Interfaces.Permissions.Catalogs.PermissionTypes.InputPorts;
using DosPinos.HRMS.Entities.DTOs.Permissions.Catalogs;

namespace DosPinos.HRMS.BusinessLogic.Iterators.Permissions.Catalogs.PermissionsTypes
{
    internal class GetAllPermissionTypeIterator(IPermissionTypeRepository permissionTypeRepository,
                                   ICreateLogIterator createLogIterator,
                                   IOutputPort outputPort) : BaseIterator(createLogIterator), IGetAllPermissionTypeInputPort
    {
        private readonly IPermissionTypeRepository _permissionTypeRepository = permissionTypeRepository;
        private readonly IOutputPort _outputPort = outputPort;

        public async Task GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all incapacity types
                IEnumerable<GetAllPermissionTypeDTO> permissionsTypes = await _permissionTypeRepository.GetAllAsync();
                response.Content = permissionsTypes;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.License, ActionCategory.GetAll, exception, entity);
            }

            _outputPort.Handle(response);
        }
    }
}
