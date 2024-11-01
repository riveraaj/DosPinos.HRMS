namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs
{
    public class GetAllDistrictDTO : EntityDTO, IGetAllDistrictDTO
    {
        public int DistrictId { get; set; }
        public string DistrictDescription { get; set; }
        public int CantonId { get; set; }
    }
}