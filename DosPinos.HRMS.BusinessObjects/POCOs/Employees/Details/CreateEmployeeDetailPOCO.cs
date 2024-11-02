using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Details.POCOs;
using DosPinos.HRMS.BusinessObjects.ValidationAttributes;

namespace DosPinos.HRMS.BusinessObjects.POCOs.Employees.Details
{
    public class CreateEmployeeDetailPOCO : ICreateEmployeeDetailPOCO
    {
        [DateWihinLastCentury]
        public DateOnly DateBirth { get; set; }

        [RequiredGreaterThanZero]
        public int Children { get; set; }
        public DateOnly DateEntry { get; } = DateOnly.FromDateTime(DateTime.Now);

        [RequiredGreaterThanZero]
        public byte MaritalStatusId { get; set; }

        [RequiredGreaterThanZero]
        public byte NationalityId { get; set; }

        [RequiredGreaterThanZero]
        public byte GenderId { get; set; }

        [RequiredGreaterThanZero]
        public byte HiringTypeId { get; set; }

        [RequiredGreaterThanZero]
        public byte JobTitleId { get; set; }
    }
}