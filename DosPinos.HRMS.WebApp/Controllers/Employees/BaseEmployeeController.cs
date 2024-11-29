using DosPinos.HRMS.Controllers.Commons.Notifications;
using DosPinos.HRMS.Controllers.Employees.Catalogs.Cantons;
using DosPinos.HRMS.Controllers.Employees.Catalogs.Districts;
using DosPinos.HRMS.Controllers.Employees.Catalogs.Genders;
using DosPinos.HRMS.Controllers.Employees.Catalogs.HiringsType;
using DosPinos.HRMS.Controllers.Employees.Catalogs.JobTitle;
using DosPinos.HRMS.Controllers.Employees.Catalogs.MaritalStatus;
using DosPinos.HRMS.Controllers.Employees.Catalogs.Nationalities;
using DosPinos.HRMS.Controllers.Employees.Catalogs.PhonesType;
using DosPinos.HRMS.Controllers.Employees.Catalogs.Provinces;
using DosPinos.HRMS.Controllers.Employees.Catalogs.SalaryCategories;
using DosPinos.HRMS.Entities.DTOs.Employees.Catalogs;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Employees.Catalogs;
using DosPinos.HRMS.WebApp.Controllers.Base;
using DosPinos.HRMS.WebApp.Models.Employees;

namespace DosPinos.HRMS.WebApp.Controllers.Employees
{
    public abstract class BaseEmployeeController(GetAllNotificationController getAllNotificationController,
                                        UpdateNotificationController updateNotificationController,
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
                                        HRMS.Controllers.Employees.EmployeeController employeeController) : BaseController(getAllNotificationController,
                                                                                                                           updateNotificationController)
    {
        private readonly GetAllDistrictController _getAllDistrictController = getAllDistrictController;
        private readonly GetAllCantonController _getAllCantonController = getAllCantonController;
        private readonly GetAllProvinceController _getAllProvinceController = getAllProvinceController;
        private readonly GetAllGenderController _getAllGenderController = getAllGenderController;
        private readonly GetAllSalaryCategoryController _getAllSalaryCategoryController = getAllSalaryCategoryController;
        private readonly GetAllNationalityController _getAllNationalityController = getAllNationalityController;
        private readonly GetAllMaritalStatusController _getAllMaritalStatusController = getAllMaritalStatusController;
        private readonly GetAllJobTitleController _getAllJobTitleController = getAllJobTitleController;
        private readonly GetAllPhoneTypeController _getAllPhoneTypeController = getAllPhoneTypeController;
        private readonly GetAllHiringTypeController _getAllHiringTypeController = getAllHiringTypeController;
        internal readonly HRMS.Controllers.Employees.EmployeeController _employeeController = employeeController;

        internal async Task<T> PopulateEmployee<T>(IEntityDTO entity) where T : BaseEmployeeViewModel, new()
        {
            IOperationResponseVO response;

            T model = new()
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

            response = await _employeeController.GetAllAsync(entity);
            model.ManagerList = response.Content as List<GetAllManagerDTO>;

            response = await _getAllProvinceController.GetAllAsync(entity);
            model.ProvinceList = response.Content as List<IGetAllProvinceDTO>;

            response = await _getAllCantonController.GetAllAsync(entity);
            model.CantonList = response.Content as List<IGetAllCantonDTO>;

            return model;
        }
    }
}