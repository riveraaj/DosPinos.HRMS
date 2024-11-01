namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs
{
    public class GetAllNationalityDTO : EntityDTO, IGetAllNationalityDTO
    {
        public int NationalityId { get; set; }
        public string NationalityDescription { get; set; }
    }
}