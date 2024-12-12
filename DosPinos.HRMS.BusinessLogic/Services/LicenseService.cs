using DosPinos.HRMS.BusinessObjects.Interfaces.Incapacities;
using DosPinos.HRMS.BusinessObjects.POCOs.Commons.Notifications;
using DosPinos.HRMS.BusinessObjects.Resources.Notifications;
using DosPinos.HRMS.Entities.DTOs.Incapacities;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class LicenseService(ILicenseRepository licenseRepository,
                                ICreateNotificationInputPort noticationInputPort,
                                ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly ILicenseRepository _licenseRepository = licenseRepository;
        private readonly ICreateNotificationInputPort _noticationInputPort = noticationInputPort;

        public async Task<IOperationResponseVO> GetAllAsync(int identification, IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = await _licenseRepository.GetAllAsync(identification);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.License, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> CreateAsync(CreateLicenseDTO licenseDTO)
        {
            IOperationResponseVO response;

            try
            {
                // Validate POCO model
                ICreateNotificationPOCO notification = new CreateNotificationPOCO()
                {
                    CreatedTo = licenseDTO.UserId,
                    CreatedFor = licenseDTO.ManagerId,
                    Message = NotificationMessage.Vacation
                };

                response = await _licenseRepository.CreateAsync(licenseDTO);

                if (response.Status == ResponseStatus.Success) await _noticationInputPort.CreateAsync(notification);
                if (response.Status == ResponseStatus.Error) throw new Exception(response.Content.ToString());
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.License, ActionCategory.Create, exception, licenseDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> EvaluateAsync(EvaluateLicenseDTO licenseDTO)
        {
            IOperationResponseVO response;

            try
            {
                response = await _licenseRepository.EvaluateAsync(licenseDTO);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.License, ActionCategory.Create, exception, licenseDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> UpdateAsync(UpdateLicenseDTO licenseDTO)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                bool result = await _licenseRepository.UpdateAsync(licenseDTO);
                if (!result) response = this.CustomWarning();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.License, ActionCategory.Update, exception, licenseDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> DeleteAsync(int licenseId, IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                bool result = await _licenseRepository.DeleteAsync(licenseId);
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