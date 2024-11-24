using DosPinos.HRMS.BusinessObjects.Interfaces.Employees.Details.POCOs;

namespace DosPinos.HRMS.BusinessObjects.POCOs.Employees.Details
{
    public class CreateEmployeeDetailPOCO : ICreateEmployeeDetailPOCO
    {
        [DateWihinLastCentury]
        public DateOnly DateBirth { get; set; }

        public int Children { get; set; }

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
        [RequiredAndMaxLength(100)]
        public string Email { get; set; }
    }
}