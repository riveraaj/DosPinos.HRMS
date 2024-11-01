namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs
{
    public class GetAllMaritalStatusDTO : EntityDTO, IGetAllMaritalStatusDTO
    {
        public int MaritalStatusId { get; set; }
        public string MaritalStatusDescription { get; set; }
    }
}