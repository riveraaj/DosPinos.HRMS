namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs
{
    public class GetAllProvinceDTO : EntityDTO, IGetAllProvinceDTO
    {
        public int ProvinceId { get; set; }
        public string ProvinceDescription { get; set; }
    }
}