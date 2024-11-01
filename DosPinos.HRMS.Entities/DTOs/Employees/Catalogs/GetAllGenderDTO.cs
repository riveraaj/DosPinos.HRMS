namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs
{
    public class GetAllGenderDTO : EntityDTO, IGetAllGenderDTO
    {
        public int GenderId { get; set; }
        public string GenderDescription { get; set; }
    }
}