namespace DosPinos.HRMS.Presenters.Presenters
{
    internal class Presenter : IOutputPort
    {
        public IOperationResponseVO OperationResponse { get; private set; }
        public void Handle(IOperationResponseVO response) => OperationResponse = response;
    }
}