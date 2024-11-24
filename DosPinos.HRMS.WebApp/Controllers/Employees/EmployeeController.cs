using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Controllers.Employees;
using DosPinos.HRMS.Controllers.Employees.Catalogs.Districts;
using DosPinos.HRMS.Controllers.Employees.Catalogs.Genders;
using DosPinos.HRMS.Controllers.Employees.Catalogs.HiringsType;
using DosPinos.HRMS.Controllers.Employees.Catalogs.JobTitle;
using DosPinos.HRMS.Controllers.Employees.Catalogs.MaritalStatus;
using DosPinos.HRMS.Controllers.Employees.Catalogs.Nationalities;
using DosPinos.HRMS.Controllers.Employees.Catalogs.PhonesType;
using DosPinos.HRMS.Controllers.Employees.Catalogs.SalaryCategories;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.DTOs.Employees;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Helpers;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Employees;
using DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;
using DosPinos.HRMS.Entities.ValueObjects;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DosPinos.HRMS.WebApp.Controllers.Employees
{
    [Authorize]
    public class EmployeeController(GetAllNotificationController getAllNotificationController,
                                    UpdateNotificationController updateNotificationController,
                                    CreateEmployeeController createController,
                                    GetAllEmployeeController getAllController,
                                    GetAllDistrictController getAllDistrictController,
                                    GetAllGenderController getAllGenderController,
                                    GetAllSalaryCategoryController getAllSalaryCategoryController,
                                    GetAllNationalityController getAllNationalityController,
                                    GetAllMaritalStatusController getAllMaritalStatusController,
                                    GetAllJobTitleController getAllJobTitleController,
                                    GetAllPhoneTypeController getAllPhoneTypeController,
                                    GetAllHiringTypeController getAllHiringTypeController,
                                    HRMS.Controllers.Employees.EmployeeController employeeController) : BaseController(getAllNotificationController,
                                                                                                                       updateNotificationController)
    {
        private readonly CreateEmployeeController _createController = createController;
        private readonly GetAllEmployeeController _getAllController = getAllController;
        private readonly GetAllDistrictController _getAllDistrictController = getAllDistrictController;
        private readonly GetAllGenderController _getAllGenderController = getAllGenderController;
        private readonly GetAllSalaryCategoryController _getAllSalaryCategoryController = getAllSalaryCategoryController;
        private readonly GetAllNationalityController _getAllNationalityController = getAllNationalityController;
        private readonly GetAllMaritalStatusController _getAllMaritalStatusController = getAllMaritalStatusController;
        private readonly GetAllJobTitleController _getAllJobTitleController = getAllJobTitleController;
        private readonly GetAllPhoneTypeController _getAllPhoneTypeController = getAllPhoneTypeController;
        private readonly GetAllHiringTypeController _getAllHiringTypeController = getAllHiringTypeController;
        private readonly HRMS.Controllers.Employees.EmployeeController _employeeController = employeeController;

        [HttpGet]
        [Route("empleados")]
        public async Task<IActionResult> Index()
        {
            EmployeeViewModel model = new();

            IOperationResponseVO response = await _getAllController.GetAllAsync(new EntityDTO()
            {
                UserId = ActualUser
            });

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            model.Employees = (List<IGetAllEmployeeDTO>)response.Content;
            model.Notifications = await this.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        [Route("nuevo-empleado")]
        public async Task<IActionResult> Create()
        {

            CreateEmployeeViewModel model = await PopulateCreateEmployee(new EntityDTO
            {
                UserId = ActualUser
            });

            if (TempData["alert"] is not null)
            {
                var alert = JsonConvert.DeserializeObject<OperationResponseVO>((string)TempData["alert"]);
                model.Response = alert;
            }

            return View(model);
        }

        [HttpPost]
        [Route("nuevo-empleado")]
        public async Task<IActionResult> Create(CreateEmployeeViewModel model)
        {
            model.EmployeeObj.UserId = ActualUser;

            model.Response = await _createController.CreateAsync(model.EmployeeObj);

            if (model.Response.Status == ResponseStatus.Success)
            {
                TempData["alert"] = JsonConvert.SerializeObject(model.Response);
                return RedirectToAction("Index");
            }

            var newModel = await PopulateCreateEmployee(new EntityDTO { UserId = ActualUser });
            newModel.Response = model.Response;
            newModel.EmployeeObj = model.EmployeeObj;

            TempData["alert"] = JsonConvert.SerializeObject(model.Response);

            if (model.Response.Status == ResponseStatus.Success) return RedirectToAction("Index");

            return View("Create", newModel);
        }

        [HttpGet]
        [Route("empleado")]
        public async Task<IActionResult> Edit(string id)
        {
            IOperationResponseVO response = await _employeeController.GetAsync(Convert.ToInt32(CryptographyHelper.Decrypt(id)), new EntityDTO()
            {
                UserId = ActualUser
            });

            if (response.Status != ResponseStatus.Success)
            {
                TempData["alert"] = JsonConvert.SerializeObject(response);
                return RedirectToAction("Index");
            }

            EditEmployeeViewModel model = new()
            {
                Employee = (GetEmployeeByIdentifactionDTO)response.Content,
                Notifications = await this.GetAllAsync()
            };

            return View(model);
        }

        private async Task<CreateEmployeeViewModel> PopulateCreateEmployee(IEntityDTO entity)
        {
            IOperationResponseVO response;

            CreateEmployeeViewModel model = new()
            {
                Notifications = await this.GetAllAsync()
            };

            response = await _getAllGenderController.GetAllAsync(entity);
            model.GenderList = response.Content as List<IGetAllGenderDTO>;

            response = await _getAllDistrictController.GetAllAsync(entity);
            model.DistrictList = response.Content as List<IGetAllDistrictDTO>;

            response = await _getAllSalaryCategoryController.GetAllAsync(entity);
            model.SalaryCategoryList = response.Content as List<IGetAllSalaryCategoryDTO>;

            response = await _getAllNationalityController.GetAllAsync(entity);
            model.NationalityList = response.Content as List<IGetAllNationalityDTO>;

            response = await _getAllMaritalStatusController.GetAllAsync(entity);
            model.MaritalStatusList = response.Content as List<IGetAllMaritalStatusDTO>;

            response = await _getAllJobTitleController.GetAllAsync(entity);
            model.JobTitleList = response.Content as List<IGetAllJobTitleDTO>;

            response = await _getAllPhoneTypeController.GetAllAsync(entity);
            model.PhoneTypeList = response.Content as List<IGetAllPhoneTypeDTO>;

            response = await _getAllHiringTypeController.GetAllAsync(entity);
            model.HiringTypeList = response.Content as List<IGetAllHiringTypeDTO>;

            return model;
        }
    }
}