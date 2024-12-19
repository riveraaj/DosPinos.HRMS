using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Controllers.Employees;
using DosPinos.HRMS.Controllers.Employees.Catalogs.Cantons;
using DosPinos.HRMS.Controllers.Employees.Catalogs.Deductions;
using DosPinos.HRMS.Controllers.Employees.Catalogs.Districts;
using DosPinos.HRMS.Controllers.Employees.Catalogs.Genders;
using DosPinos.HRMS.Controllers.Employees.Catalogs.HiringsType;
using DosPinos.HRMS.Controllers.Employees.Catalogs.JobTitle;
using DosPinos.HRMS.Controllers.Employees.Catalogs.MaritalStatus;
using DosPinos.HRMS.Controllers.Employees.Catalogs.Nationalities;
using DosPinos.HRMS.Controllers.Employees.Catalogs.PhonesType;
using DosPinos.HRMS.Controllers.Employees.Catalogs.Provinces;
using DosPinos.HRMS.Controllers.Employees.Catalogs.SalaryCategories;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.Employees;
using DosPinos.HRMS.Entities.DTOs.Employees.Deductions;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Helpers;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Employees;
using DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Models.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Employees
{
    [Authorize(Roles = "2, 6, 4, 5")]
    public class EmployeeController(GetAllNotificationController getAllNotificationController,
                                        UpdateNotificationController updateNotificationController,
                                        CreateEmployeeController createController,
                                        GetAllEmployeeController getAllController,
                                        GetAllDistrictController getAllDistrictController,
                                        GetAllCantonController getAllCantonController,
                                        GetAllProvinceController getAllProvinceController,
                                        GetAllGenderController getAllGenderController,
                                        GetAllSalaryCategoryController getAllSalaryCategoryController,
                                        GetAllNationalityController getAllNationalityController,
                                        GetAllMaritalStatusController getAllMaritalStatusController,
                                        GetAllJobTitleController getAllJobTitleController,
                                        GetAllPhoneTypeController getAllPhoneTypeController,
                                        GetAllHiringTypeController getAllHiringTypeController,
                                        HRMS.Controllers.Employees.EmployeeController employeeController,
                                        GetAllDeductionController deductionsIP,
                                        HRMS.Controllers.Employees.EmployeeDeductionController deductionController) : BaseEmployeeController(getAllNotificationController,
                                                                                                                                   updateNotificationController,
                                                                                                                                   getAllDistrictController,
                                                                                                                                   getAllCantonController,
                                                                                                                                   getAllProvinceController,
                                                                                                                                   getAllGenderController,
                                                                                                                                   getAllSalaryCategoryController,
                                                                                                                                   getAllNationalityController,
                                                                                                                                   getAllMaritalStatusController,
                                                                                                                                   getAllJobTitleController,
                                                                                                                                   getAllPhoneTypeController,
                                                                                                                                   getAllHiringTypeController,
                                                                                                                                   employeeController)
    {
        private readonly CreateEmployeeController _createController = createController;
        private readonly GetAllEmployeeController _getAllController = getAllController;
        private readonly GetAllDeductionController _deductionsIP = deductionsIP;
        private readonly HRMS.Controllers.Employees.EmployeeDeductionController _deductionController = deductionController;

        [Route("empleados")]
        public async Task<IActionResult> Index()
        {
            EmployeeViewModel model = new();

            IOperationResponseVO response = await _getAllController.GetAllAsync(new EntityDTO() { UserId = ActualUser });

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            model.Employees = response.Content as List<IGetAllEmployeeDTO>;
            model.Notifications = await this.GetAllNotificationAsync();

            return View(model);
        }

        [Route("empleados/nuevo-empleado")]
        public async Task<IActionResult> Create()
        {
            CreateEmployeeViewModel model = await this.PopulateEmployee<CreateEmployeeViewModel>(new EntityDTO { UserId = ActualUser });

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            return View(model);
        }

        [HttpPost]
        [Route("empleados/nuevo-empleado")]
        public async Task<IActionResult> Create(CreateEmployeeViewModel model)
        {
            model.EmployeeObj.UserId = ActualUser;

            model.Response = await _createController.CreateAsync(model.EmployeeObj);

            if (model.Response.Status == ResponseStatus.Success)
            {
                TempData["alert"] = JsonConvert.SerializeObject(model.Response);
                return RedirectToAction("Index");
            }

            var newModel = await this.PopulateEmployee<CreateEmployeeViewModel>(new EntityDTO { UserId = ActualUser });
            newModel.Response = model.Response;
            newModel.EmployeeObj = model.EmployeeObj;

            TempData["alert"] = JsonConvert.SerializeObject(model.Response);

            if (model.Response.Status == ResponseStatus.Success) return RedirectToAction("Index");

            return View("Create", newModel);
        }

        [Route("empleados/editar-empleado")]
        public async Task<IActionResult> Edit(string id)
        {
            EditEmployeeViewModel model = await this.PopulateEmployee<EditEmployeeViewModel>(Entity);

            IOperationResponseVO response = await _deductionsIP.GetAllAsync(Entity);
            model.DeductionList = response.Content as List<IGetAllDeductionDTO>;

            response = await _deductionController.GetAllAsync(ActualEmployee, Entity);
            model.EmployeeDeductions = response.Content as List<GetAllEmployeeDeductionDTO>;

            response = await this._employeeController.GetAsync(Convert.ToInt32(CryptographyHelper.Decrypt(id)), Entity);

            if (response.Status != ResponseStatus.Success)
            {
                TempData["alert"] = JsonConvert.SerializeObject(response);
                return RedirectToAction("Index");
            }

            model.EmployeeObj = response.Content as GetEmployeeByIdentifactionDTO;

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            return View(model);
        }

        [Route("empleados/editar-empleado")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditEmployeeViewModel model)
        {
            model.UpdateEmployeeObj.EmployeeObj.UserId = ActualUser;
            model.UpdateEmployeeObj.EmployeeObj.ManagerId = model.EmployeeObj.ManagerId;

            IOperationResponseVO response = await _employeeController.UpdateAsync(model.UpdateEmployeeObj.EmployeeObj);

            return Json(new
            {
                success = response.Status == ResponseStatus.Success,
                message = response.Message.FirstOrDefault(),
                status = response.Status.ToString()
            });
        }
    }
}