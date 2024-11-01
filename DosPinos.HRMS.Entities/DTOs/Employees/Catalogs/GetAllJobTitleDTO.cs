namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs
{
    public class GetAllJobTitleDTO : EntityDTO, IGetAllJobTitleDTO
    {
        public int JobTitleId { get; set; }
        public string JobTitleDescription { get; set; }
    }
}