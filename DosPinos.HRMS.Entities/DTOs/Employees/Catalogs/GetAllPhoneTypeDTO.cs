namespace DosPinos.HRMS.Entities.DTOs.Employees.Catalogs
{
    public class GetAllPhoneTypeDTO : EntityDTO, IGetAllPhoneTypeDTO
    {
        public int PhoneTypeId { get; set; }
        public string PhoneTypeDescription { get; set; }
    }
}