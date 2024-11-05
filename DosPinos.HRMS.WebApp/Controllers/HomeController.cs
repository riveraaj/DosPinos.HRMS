using DosPinos.HRMS.Controllers.Employees;
using DosPinos.HRMS.Entities.DTOs.Commons.Base;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DosPinos.HRMS.WebApp.Controllers
{
    public class HomeController(GetAllEmployeeController controller,
                                ILogger<HomeController> logger) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly GetAllEmployeeController _controller = controller;

        public async Task<IActionResult> Index()
        {
            IOperationResponseVO response = await _controller.GetAllAsync(new EntityDTO()
            {
                UserId = 1
            });

            //IOperationResponseVO response = await _controller.CreateAsync(new CreateEntireEmployeeDTO()
            //{
            //    Address = new CreateAddressDTO()
            //    {
            //        Address = "Test01",
            //        DistrictId = 1
            //    },
            //    Compensation = new CreateEmployeeCompensationDTO()
            //    {
            //        SalaryCategoryId = 1
            //    },
            //    Deduction = new CreateEmployeeDeductionDTO()
            //    {
            //        DeductionAmount = 1,
            //        DeductionId = 1
            //    },
            //    Detail = new CreateEmployeeDetailDTO()
            //    {
            //        Children = 0,
            //        DateBirth = new DateOnly(2003, 7, 17),
            //        GenderId = 2,
            //        HiringTypeId = 1,
            //        JobTitleId = 1,
            //        MaritalStatusId = 1,
            //        NationalityId = 1
            //    },
            //    Phone = new CreatePhoneDTO()
            //    {
            //        PhoneNumber = "87849928",
            //        PhoneTypeId = 1
            //    },
            //    Employee = new CreateEmployeeDTO()
            //    {
            //        FirstLastName = "Test",
            //        Identification = 123456789,
            //        ManagerId = 5,
            //        Name = "Test",
            //        SecondLastName = "Test",
            //        HasManager = true
            //    }
            //});

            //IOperationResponseVO response = await _roleController.GetAllAsync(new EntityDTO
            //{
            //    UserId = 1
            //});

            //List<IGetAllRoleDTO> roleList = (List<IGetAllRoleDTO>)response.Content;

            Console.WriteLine(response);
            return View(response.Content);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
