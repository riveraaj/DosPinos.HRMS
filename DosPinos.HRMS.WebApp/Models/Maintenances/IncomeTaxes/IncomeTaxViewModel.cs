using DosPinos.HRMS.Entities.DTOs.IncomeTaxes;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Maintenances;

namespace DosPinos.HRMS.WebApp.Models.Maintenances.IncomeTaxes
{
    public class IncomeTaxViewModel : BaseViewModel
    {
        public IncomeTaxViewModel()
        {
            this.Title = MaintenanceLabel.IncomeTaxTitle;
            IncomeTaxObj = new();
            UpdateIncomeTaxObj = new();
            IncomeTaxes = [];
        }

        public CreateIncomeTaxDTO IncomeTaxObj { get; set; }
        public UpdateIncomeTaxDTO UpdateIncomeTaxObj { get; set; }
        public List<GetAllIncomeTaxTableDTO> IncomeTaxes { get; set; }
    }
}