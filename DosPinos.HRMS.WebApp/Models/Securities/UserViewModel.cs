using DosPinos.HRMS.Entities.DTOs.Securities;
using DosPinos.HRMS.Entities.Interfaces.Securities.Catalogs;
using DosPinos.HRMS.WebApp.Models.Base;
using DosPinos.HRMS.WebApp.Resources.Securities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DosPinos.HRMS.WebApp.Models.Securities
{
    public class UserViewModel : BaseViewModel
    {
        public UserViewModel()
        {
            this.Title = SecurityLabel.Title;
            UpdateUserObj = new();
            Users = [];
            RoleList = [];
            EmployeeList = [];
        }

        public CreateUserDTO UserObj { get; set; }
        public DeleteUserDTO DeleteUserObj { get; set; }
        public UpdateUserDTO UpdateUserObj { get; set; }
        public List<GetAllUserDTO> Users { get; set; }
        public List<IGetAllRoleDTO> RoleList { get; set; }
        public List<GetAllWithoutUserDTO> EmployeeList { get; set; }
        public List<SelectListItem> Roles => RoleList.Select(r => new SelectListItem
        {
            Value = r.RoleId.ToString(),
            Text = r.RoleDescription,
        }).ToList();
        public List<SelectListItem> Employees => EmployeeList.Select(e => new SelectListItem
        {
            Value = e.EmployeeId.ToString(),
            Text = e.FullName,
        }).ToList();
    }
}