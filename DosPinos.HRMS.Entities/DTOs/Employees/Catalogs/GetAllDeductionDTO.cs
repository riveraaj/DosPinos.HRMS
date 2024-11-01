namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs
{
    public class GetAllDeductionDTO : EntityDTO, IGetAllDeductionDTO
    {
        public int DeductionId { get; set; }
        public string DeductionDescription { get; set; }
        public decimal DeductionPercentage { get; set; }
    }
}