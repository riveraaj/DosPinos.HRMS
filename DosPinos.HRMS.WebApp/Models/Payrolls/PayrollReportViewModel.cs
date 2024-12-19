using DosPinos.HRMS.Entities.DTOs.Payroll;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Payrolls;

namespace DosPinos.HRMS.WebApp.Models.Payrolls
{
    public class PayrollReportViewModel : BaseViewModel
    {
        public PayrollReportViewModel()
        {
            this.Title = PayrollLabel.PayrollReportTitle;
            Payrolls = [];
        }

        public List<GetAllPayrollByEmployeeDTO> Payrolls { get; set; }
    }
}