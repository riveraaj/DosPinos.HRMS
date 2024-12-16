namespace DosPinos.HRMS.Entities.DTOs.Employees.Details
{
    public class UpdateEmployeeDetailDTO : EntityDTO, IEntityDTO
    {
        public int EmployeeId { get; set; }
        public DateOnly DateBirth { get; set; }
        public int Children { get; set; }
        public int MaritalStatusId { get; set; }
        public int NationalityId { get; set; }
        public int GenderId { get; set; }
        public int HiringTypeId { get; set; }
        public int JobTitleId { get; set; }
    }
}