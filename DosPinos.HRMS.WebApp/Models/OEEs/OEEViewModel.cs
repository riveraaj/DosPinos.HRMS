using DosPinos.HRMS.Entities.DTOs.Employees;
using DosPinos.HRMS.Entities.DTOs.Machines;
using DosPinos.HRMS.Entities.DTOs.OEEs;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.OEEs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DosPinos.HRMS.WebApp.Models.OEEs
{
    public class OEEViewModel : BaseViewModel
    {
        public OEEViewModel()
        {
            this.Title = OEELabel.Title;
            OEEObj = new();
            OEEs = [];
            EmployeeList = [];
            MachineList = [];
        }

        public CreateOEEDTO OEEObj { get; set; }
        public List<GetAllOEEDTO> OEEs { get; set; }
        public List<GetAllActiveEmployeeDTO> EmployeeList { get; set; }

        public List<GetAllMachineDTO> MachineList { get; set; }

        public List<SelectListItem> Employees => EmployeeList.Select(e => new SelectListItem
        {
            Value = e.EmployeeId.ToString(),
            Text = e.FullName,
        }).ToList();

        public List<SelectListItem> Machines => MachineList.Select(m => new SelectListItem
        {
            Value = m.MachineId.ToString(),
            Text = m.Description,
        }).ToList();
    }
}