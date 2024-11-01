namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs
{
    public class GetAllSalaryCategoryDTO : EntityDTO, IGetAllSalaryCategoryDTO
    {
        public int SalaryCategoryId { get; set; }
        public string SalaryCategoryDescription { get; set; }
        public decimal SalaryCategoryRange { get; set; }
    }
}