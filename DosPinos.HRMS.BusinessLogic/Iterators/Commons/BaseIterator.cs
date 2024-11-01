namespace DosPinos.HRMS.BusinessLogic.Iterators.Commons
{
    internal abstract class BaseIterator(ICreateLogIterator createLogIterator)
    {
        private readonly ICreateLogIterator _createLogIterator = createLogIterator;

        public IOperationResponseVO HandlerLog(Module module, ActionCategory action, Exception ex, IEntityDTO entity)
        {
            var (className, methodName) = CallerHelper.GetCallerInfo();
            string source = string.Format(Resources.Commons.Commons.SourceMessage, className,
                                                                                   methodName);
            ILogPOCO log = new LogPOCO
            {
                Action = action,
                Exeption = ex.ToString(),
                Message = ex.Message,
                Module = module,
                Source = source,
                TimeStamp = DateTime.Now,
                UserId = entity.UserId
            };

            _createLogIterator.Create(log);

            return CustomError(Resources.Commons.Commons.ErrorMessage);
        }

        public IOperationResponseVO CustomWarning(string message) => new OperationResponseVO()
        {
            Status = ResponseStatus.Warning,
            Content = null,
            Message = [message]
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