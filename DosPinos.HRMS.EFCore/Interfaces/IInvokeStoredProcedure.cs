using DosPinos.HRMS.Entities.Interfaces.Commons.Base;

namespace DosPinos.HRMS.EFCore.Interfaces
{
    internal interface IInvokeStoredProcedure
    {
        Task<IOperationResponseVO> ExecuteAsync(string storedProcedureName,
                                                Dictionary<string, object> parameters,
                                                bool isReadOperation);
    }
}