namespace DosPinos.HRMS.BusinessObjects.Interfaces.Employees.POCOs
{
    public interface ICreateEmployeePOCO
    {
        int Identification { get; set; }
        string Name { get; set; }
        string FirstLastName { get; set; }
        string SecondLastName { get; set; }
        int ManagerId { get; set; }
        bool HasManager { get; set; }
        string Email { get; set; }
    }
}