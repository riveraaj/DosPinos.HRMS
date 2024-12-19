using DosPinos.HRMS.Entities.DTOs.SalaryCategories;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class SalaryCategoryService(ISalaryCategoryRepository repository,
                            ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly ISalaryCategoryRepository _repository = repository;


        public async Task<IOperationResponseVO> CreateAsync(CreateSalaryCategoryDTO salaryCategoryDTO)
        {
            IOperationResponseVO response;

            try
            {
                response = await _repository.CreateAsync(salaryCategoryDTO);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, salaryCategoryDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> DeleteAsync(byte salarYCategoryId, IEntityDTO entity)
        {
            IOperationResponseVO response;

            try
            {
                response = await _repository.DeleteAsync(salarYCategoryId);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Delete, exception, entity);
            }

            return response;
        }
    }
}