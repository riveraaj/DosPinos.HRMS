using DosPinos.HRMS.BusinessObjects.Interfaces.Vacations;
using DosPinos.HRMS.BusinessObjects.POCOs.Commons.Notifications;
using DosPinos.HRMS.BusinessObjects.Resources.Notifications;
using DosPinos.HRMS.Entities.DTOs.Vacations;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class VacationService(IVacationRepository vacationRepository,
                                 ICreateNotificationInputPort noticationInputPort,
                                 ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IVacationRepository _vacationRepository = vacationRepository;
        private readonly ICreateNotificationInputPort _noticationInputPort = noticationInputPort;

        public async Task<IOperationResponseVO> GetAsync(int identification, IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = await _vacationRepository.GetAsync(identification);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Vacation, ActionCategory.Get, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> GetAllByEmployeeAsync(int identification, IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                response.Content = await _vacationRepository.GetAllAsync(identification);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Vacation, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> CreateAsync(CreateVacationDTO vacationDTO)
        {
            IOperationResponseVO response;

            try
            {
                ICreateNotificationPOCO notification = new CreateNotificationPOCO()
                {
                    CreatedTo = vacationDTO.UserId,
                    CreatedFor = vacationDTO.ManagerId,
                    Message = NotificationMessage.Vacation
                };

                response = await _vacationRepository.CreateAsync(vacationDTO);

                if (response.Status == ResponseStatus.Success) await _noticationInputPort.CreateAsync(notification);
                if (response.Status == ResponseStatus.Error) throw new Exception(response.Content.ToString());
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Vacation, ActionCategory.Create, exception, vacationDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> EvaluateAsync(EvaluateVacationDTO vacationDTO)
        {
            IOperationResponseVO response;

            try
            {
                response = await _vacationRepository.EvaluateAsync(vacationDTO);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Vacation, ActionCategory.Create, exception, vacationDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> UpdateAsync(UpdateVacationDTO vacationDTO)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                bool result = await _vacationRepository.UpdateAsync(vacationDTO);
                if (!result) response = this.CustomWarning();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Vacation, ActionCategory.Update, exception, vacationDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> DeleteAsync(int vacationId, IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                bool result = await _vacationRepository.DeleteAsync(vacationId);
                if (!result) response = this.CustomWarning();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Vacation, ActionCategory.Delete, exception, entity);
            }

            return response;
        }
    }
}