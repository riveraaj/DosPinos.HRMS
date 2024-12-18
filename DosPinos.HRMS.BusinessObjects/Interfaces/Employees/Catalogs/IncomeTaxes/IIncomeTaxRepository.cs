using DosPinos.HRMS.Entities.DTOs.IncomeTaxes;

namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Catalogs.IncomeTaxes
{
    public interface IIncomeTaxRepository
    {
        Task<IEnumerable<GetAllIncomeTaxTableDTO>> GetAllTableAsync();
        Task<IEnumerable<IGetAllIncomeTaxDTO>> GetAllAsync();
        Task<IOperationResponseVO> CreateAsync(CreateIncomeTaxDTO incomeTaxDTO);

        Task<IOperationResponseVO> UpdateAsync(UpdateIncomeTaxDTO incomeTaxDTO);

        Task<IOperationResponseVO> DeleteAsync(byte incomeTaxId);
    }
}