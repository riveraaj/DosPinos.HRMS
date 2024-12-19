using DosPinos.HRMS.BusinessObjects.Interfaces.Machines;
using DosPinos.HRMS.Entities.DTOs.Machines;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class MachineService(IMachineRepository repository,
                            ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly IMachineRepository _repository = repository;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();
            try
            {
                response.Content = await _repository.GetAllAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> GetAllTableAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();
            try
            {
                response.Content = await _repository.GetAllTableAsync();
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.GetAll, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> CreateAsync(CreateMachineDTO machineDTO)
        {
            IOperationResponseVO response;

            try
            {
                response = await _repository.CreateAsync(machineDTO);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, machineDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> UpdateAsync(UpdateMachineDTO machineDTO)
        {
            IOperationResponseVO response;

            try
            {
                response = await _repository.UpdateAsync(machineDTO);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Create, exception, machineDTO);
            }

            return response;
        }

        public async Task<IOperationResponseVO> DeleteAsync(byte machineId, IEntityDTO entity)
        {
            IOperationResponseVO response;

            try
            {
                response = await _repository.DeleteAsync(machineId);
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Maintenance, ActionCategory.Delete, exception, entity);
            }

            return response;
        }
    }
}