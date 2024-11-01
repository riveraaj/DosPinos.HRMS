namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs
{
    public class GetAllIncomeTaxDTO : EntityDTO, IGetAllIncomeTaxDTO
    {
        public int IncomeTaxId { get; set; }
        public decimal IncomeTaxPercentage { get; set; }
    }
}