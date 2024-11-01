namespace DosPinos.HRMS.BusinessLogic.Helpers
{
    internal static class CallerHelper
    {
        public static (string ClassName, string MethodName) GetCallerInfo()
        {
            StackTrace stackTrace = new();
            StackFrame frame = stackTrace.GetFrame(2);

            var method = frame?.GetMethod();
            var className = method?.DeclaringType?.FullName ?? Commons.CallerClass;
            var methodName = method?.Name ?? Commons.CallerMethod;

            return (className, methodName);
        }
    }
}