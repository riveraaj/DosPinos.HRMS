using DosPinos.HRMS.BusinessObjects.Interfaces.Machines;
using DosPinos.HRMS.Entities.DTOs.Machines;

namespace DosPinos.HRMS.EFCore.Repositories.Machines
{
    internal class MachineRepository(DospinosdbContext context) : IMachineRepository
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IEnumerable<GetAllMachineDTO>> GetAllAsync()
        {
            List<Machine> machines = await _context.Machines.ToListAsync();
            return machines.Select(x => new GetAllMachineDTO
            {
                MachineId = x.MachineId,
                Description = x.MachineDescription,
            }).ToList();
        }
    }
}