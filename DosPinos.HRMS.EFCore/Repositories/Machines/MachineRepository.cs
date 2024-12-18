using DosPinos.HRMS.BusinessObjects.Interfaces.Machines;
using DosPinos.HRMS.Entities.DTOs.Machines;

namespace DosPinos.HRMS.EFCore.Repositories.Machines
{
    internal class MachineRepository(DospinosdbContext context,
                                     IInvokeStoredProcedure invokeSP) : IMachineRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IOperationResponseVO> CreateAsync(CreateMachineDTO machineDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@machineDescription", machineDTO.Description},
                {"@machineProduction", machineDTO.MachineProduction},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateMachine", parameters, false);
        }

        public async Task<IOperationResponseVO> DeleteAsync(byte machineId)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@machineId", machineId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_DeleteMachine", parameters, false);
        }

        public async Task<IEnumerable<GetAllMachineDTO>> GetAllAsync()
        {
            List<Machine> machines = await _context.Machines.ToListAsync();
            return machines.Select(x => new GetAllMachineDTO
            {
                MachineId = x.MachineId,
                Description = x.MachineDescription,
            }).ToList();
        }

        public async Task<IEnumerable<GetAllMachineTableDTO>> GetAllTableAsync()
        {
            List<Machine> machines = await _context.Machines.ToListAsync();
            return machines.Select(x => new GetAllMachineTableDTO
            {
                MachineId = x.MachineId,
                Description = x.MachineDescription,
                Production = x.MachineProduction ?? 0,
            }).ToList();
        }

        public async Task<IOperationResponseVO> UpdateAsync(UpdateMachineDTO machineDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@machineId", machineDTO.MachineId},
                 {"@machineProduction", machineDTO.Production},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_UpdateMachine", parameters, false);
        }
    }
}