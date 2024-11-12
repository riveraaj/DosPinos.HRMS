using System.Runtime.CompilerServices;

namespace DosPinos.HRMS.BusinessLogic.Iterators.Commons
{
    public abstract class BaseIterator(ICreateLogIterator createLogIterator)
    {
        private readonly ICreateLogIterator _createLogIterator = createLogIterator;

        public async Task<IOperationResponseVO> HandlerLog(Module module, ActionCategory action, Exception ex, IEntityDTO entity,
                                                           [CallerMemberName] string callerMethodName = "",
                                                           [CallerFilePath] string callerFilePath = "")
        {
            string className = Path.GetFileNameWithoutExtension(callerFilePath)?.Split('\\').Last();

            string source = string.Format(BusinessObjects.Resources.Commons.Commons.SourceMessage, className,
                                                                                                   callerMethodName);
            ILogPOCO log = new LogPOCO
            {
                Action = action,
                Exeption = $"Error Type: {ex.GetType()}, Error Trace: {ex.StackTrace[..Math.Min(400, ex.StackTrace.Length)]}",
                Message = ex.Message,
                Module = module,
                Source = source,
                TimeStamp = DateTime.Now,
                UserId = entity.UserId
            };

            await _createLogIterator.CreateAsync(log);

            return CustomError(BusinessObjects.Resources.Commons.Commons.ErrorMessage);
        }

        public IOperationResponseVO CustomWarning(string message) => new OperationResponseVO()
        {
            Status = ResponseStatus.Warning,
            Content = null,
            Message = [message ?? BusinessObjects.Resources.Commons.Commons.WarningMessage]
        };

        public IOperationResponseVO CustomWarning() => new OperationResponseVO()
        {
            Status = ResponseStatus.Warning,
            Content = null,
            Message = [BusinessObjects.Resources.Commons.Commons.WarningMessage]
        };

        public IOperationResponseVO CustomWarning(List<string> messages) => new OperationResponseVO()
        {
            Status = ResponseStatus.Warning,
            Content = null,
            Message = messages
        };

        private static IOperationResponseVO CustomError(string message) => new OperationResponseVO()
        {
            Status = ResponseStatus.Error,
            Content = null,
            Message = [message]
        };
    }
}