using DosPinos.HRMS.BusinessObjects.Interfaces.Incapacities;
using DosPinos.HRMS.Entities.DTOs.Incapacities;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class LicenseService(ILicenseRepository licenseRepository,
                                ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly ILicenseRepository _licenseRepository = licenseRepository;

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
                response = await _licenseRepository.CreateAsync(licenseDTO);

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