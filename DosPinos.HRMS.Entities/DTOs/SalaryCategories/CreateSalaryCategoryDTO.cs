namespace DosPinos.HRMS.Entities.DTOs.SalaryCategories
{
    public class CreateSalaryCategoryDTO : EntityDTO, IEntityDTO
    {
        public string Description { get; set; }
        public decimal Range { get; set; }
        public byte IncomeTaxId { get; set; }
    }
}