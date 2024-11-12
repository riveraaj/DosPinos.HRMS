using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Details.POCOs;
using DosPinos.HRMS.BusinessObjects.POCOs.Employees.Details;
using DosPinos.HRMS.Entities.Interfaces.Employees.Details;

namespace DosPinos.HRMS.BusinessLogic.Mappers
{
    internal static class EmployeeDetailMapper
    {
        public static ICreateEmployeeDetailPOCO MapFrom(ICreateEmployeeDetailDTO detailDTO)
            => new CreateEmployeeDetailPOCO
            {
                Children = detailDTO.Children,
                DateBirth = detailDTO.DateBirth,
                GenderId = detailDTO.GenderId,
                HiringTypeId = detailDTO.HiringTypeId,
                JobTitleId = detailDTO.JobTitleId,
                MaritalStatusId = detailDTO.MaritalStatusId,
                NationalityId = detailDTO.NationalityId,
                Email = detailDTO.Email,
            };
    }
}