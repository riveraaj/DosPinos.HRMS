using DosPinos.HRMS.BusinessObjects.Interfaces.Liquidation;
using DosPinos.HRMS.Entities.DTOs.Liquidation;

namespace DosPinos.HRMS.BusinessLogic.Services
{
    public class LiquidationService(ILiquidationRepository liquidationRepository,
                                    ICreateLogIterator createLogIterator) : BaseIterator(createLogIterator)
    {
        private readonly ILiquidationRepository _liquidationRepository = liquidationRepository;

        public async Task<IOperationResponseVO> GetAllAsync(IEntityDTO entity)
        {
            IOperationResponseVO response = new OperationResponseVO();

            try
            {
                //Get all
                IEnumerable<GetAllLiquidationDTO> liquidations = await _liquidationRepository.GetAllAsync();

                response.Content = liquidations.ToList();

            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Liquidation, ActionCategory.Get, exception, entity);
            }

            return response;
        }

        public async Task<IOperationResponseVO> CreateAsync(CreateLiquidationDTO liquidationDTO)
        {
            IOperationResponseVO response = new OperationResponseVO();
            try
            {
                IOperationResponseVO result = await _liquidationRepository.CreateAsync(liquidationDTO);

                if (result.Status == ResponseStatus.Warning) response = this.CustomWarning("Hubo un problema al calcular la liquidación para el empleado.");
                if (result.Status == ResponseStatus.Error) throw new Exception(result.Message.FirstOrDefault());
                else response = result;
            }
            catch (Exception exception)
            {
                response = await this.HandlerLog(Module.Liquidation, ActionCategory.Get, exception, liquidationDTO);
            }

            return response;
        }
    }
}