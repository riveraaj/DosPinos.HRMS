using DosPinos.HRMS.Entities.DTOs.Holidays;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class HolidayService(IHolidayRepository repository,
                            ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IHolidayRepository _repository = repository;

        public async Task<IOperationResponseVO> CreateASync(CreateHolidayDTO holidayDTO)
        {
            IOperationResponseVO response;

            try
            {
                response = await _repository.CreateAsync(holidayDTO);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, holidayDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> UpdateAsync(UpdateHolidayDTO holidayDTO)
        {
            IOperationResponseVO response;

            try
            {
                response = await _repository.UpdateAsync(holidayDTO);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, holidayDTO);
            }

            return response;
        }
    }
}