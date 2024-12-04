using DosPinos.HRMS.Entities.DTOs.Payroll;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Payrolls;

namespace DosPinos.HRMS.WebApp.Models.Payrolls
{
    public class PayrollViewModel : BaseViewModel
    {
        public PayrollViewModel()
        {
            this.Title = PayrollLabel.Title;
            Payroll = [];
        }

        public List<GetPayrollByDateDTO> Payroll { get; set; }
        public string Today { get; set; }
    }
}