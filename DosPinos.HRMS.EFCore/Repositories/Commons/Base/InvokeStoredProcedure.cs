using DosPinos.HRMS.EFCore.Interfaces;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.ValueObjects;
using System.Data;

namespace DosPinos.HRMS.EFCore.Repositories.Commons.Base
{
    internal class InvokeStoredProcedure(DospinosdbContext context) : BaseStoredProcedure(context),
                                                                      IInvokeStoredProcedure
    {
        private readonly DospinosdbContext _context = context;

        public async Task<IOperationResponseVO> ExecuteAsync(string storedProcedureName,
                                                             Dictionary<string, object> parameters = null,
                                                             bool isReadOperation = false)
        {
            if (string.IsNullOrWhiteSpace(storedProcedureName))
                throw new ArgumentException("Stored procedure name cannot be null or empty", nameof(storedProcedureName));

            IOperationResponseVO response = new OperationResponseVO
            {
                Status = ResponseStatus.Error,
                Message = [],
                Content = null
            };

            // Building the command
            using var command = this.CreateCommand(storedProcedureName, parameters);

            // Open the connection if it's not already open
            if (command.Connection.State != ConnectionState.Open)
                await command.Connection.OpenAsync();

            if (isReadOperation)
            {
                response.Content = await ExecuteReadAsync(command);
                response.Status = ResponseStatus.Success;
            }
            else response = await this.ExecuteWriteAsync(command);

            //Close connection if it's open
            if (command.Connection.State == ConnectionState.Open) await command.Connection.CloseAsync();

            return response;
        }
    }
}