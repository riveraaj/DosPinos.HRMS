namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs
{
    public class GetAllCantonDTO : EntityDTO, IGetAllCantonDTO
    {
        public int CantonId { get; set; }
        public string CantonDescription { get; set; }
        public int ProvinceId { get; set; }
    }
}