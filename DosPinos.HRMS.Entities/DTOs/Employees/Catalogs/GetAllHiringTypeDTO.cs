namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs
{
    public class GetAllHiringTypeDTO : EntityDTO, IGetAllHiringTypeDTO
    {
        public int HiringTypeId { get; set; }
        public string HiringTypeDescription { get; set; }
    }
}