namespace DosPinos.HRMS.BusinessObjects.Interfaces.Securities
{
    public interface ILoginUserPOCO
    {
        string UserName { get; set; }
        string Password { get; set; }
        Status Status { get; set; }
    }
}