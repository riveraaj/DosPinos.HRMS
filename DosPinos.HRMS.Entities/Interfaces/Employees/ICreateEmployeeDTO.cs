namespace DosPinos.HRMS.Entities.Interfaces.Employees
{
    public interface ICreateEmployeeDTO : IEntityDTO
    {
        int Identification { get; set; }
        string Name { get; set; }
        string FirstLastName { get; set; }
        string SecondLastName { get; set; }
        int ManagerId { get; set; }
        bool HasManager { get; set; }
    }
}