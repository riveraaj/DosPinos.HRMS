using DosPinos.HRMS.Entities.DTOs.Machines;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Maintenances;

namespace DosPinos.HRMS.WebApp.Models.Maintenances.Machines
{
    public class MachineViewModel : BaseViewModel
    {
        public MachineViewModel()
        {
            this.Title = MaintenanceLabel.MachineTitle;
            MachineObj = new();
            UpdateMachineObj = new();
            Machines = [];
        }

        public CreateMachineDTO MachineObj { get; set; }
        public UpdateMachineDTO UpdateMachineObj { get; set; }
        public List<GetAllMachineTableDTO> Machines { get; set; }
    }
}