using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Addresses;
using DosPinos.HRMS.Entities.DTOs.Employees.Addresses;

namespace DosPinos.HRMS.EFCore.Repositories.Employees
{
    internal class AddressRepository(DospinosdbContext context,
                                      IInvokeStoredProcedure invokeSP) : IAddressRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IOperationResponseVO> UpdateAsync(UpdateAddressDTO addressDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@employeeId", addressDTO.EmployeeId},
                {"@address", addressDTO.Address},
                {"@district", addressDTO.DistrictId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_UpdateAddress", parameters, false);
        }
    }
}