namespace DosPinos.HRMS.BusinessObjects.Interfaces.Commons.OutputPorts
{
    public interface IOutputPort
    {
        IOperationResponseVO OperationResponse { get; }
        void Handle(IOperationResponseVO oOperationResponse);
    }
}