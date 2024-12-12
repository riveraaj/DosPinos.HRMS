using DosPinos.HRMS.BusinessObjects.Interfaces.Permissions;
using DosPinos.HRMS.BusinessObjects.POCOs.Commons.Notifications;
using DosPinos.HRMS.BusinessObjects.Resources.Notifications;
using DosPinos.HRMS.Entities.DTOs.Permissions;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class PermissionService(IPermissionRepository permissionRepository,
                                    ICreateNotificationInputPort noticationInputPort,
                                    ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IPermissionRepository _permissionRepository = permissionRepository;
        private readonly ICreateNotificationInputPort _noticationInputPort = noticationInputPort;

        public async Task<IOperationResponseVO> GetAllAsync(int identification, IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = await _permissionRepository.GetAllAsync(identification);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.License, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> CreateAsync(CreatePermissionDTO permissionDTO)
        {
            IOperationResponseVO response;

            try
            {
                // Validate POCO model
                ICreateNotificationPOCO notification = new CreateNotificationPOCO()
                {
                    CreatedTo = permissionDTO.UserId,
                    CreatedFor = permissionDTO.ManagerId,
                    Message = NotificationMessage.SpecialPermission
                };

                response = await _permissionRepository.CreateAsync(permissionDTO);

                if (response.Status == ResponseStatus.Success) await _noticationInputPort.CreateAsync(notification);
                if (response.Status == ResponseStatus.Error) throw new Exception(response.Content.ToString());
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.License, ActionCategory.Create, exception, permissionDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> EvaluateAsync(EvaluatePermissionDTO permissionDTO)
        {
            IOperationResponseVO response;

            try
            {
                response = await _permissionRepository.EvaluateAsync(permissionDTO);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.License, ActionCategory.Create, exception, permissionDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> UpdateAsync(UpdatePermissionDTO permissionDTO)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                bool result = await _permissionRepository.UpdateAsync(permissionDTO);
                if (!result) response = this.CustomWarning();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.License, ActionCategory.Update, exception, permissionDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> DeleteAsync(int permissionId, IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                bool result = await _permissionRepository.DeleteAsync(permissionId);
                if (!result) response = this.CustomWarning();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.License, ActionCategory.Delete, exception, entity);
            }

            return response;
        }
    }
}