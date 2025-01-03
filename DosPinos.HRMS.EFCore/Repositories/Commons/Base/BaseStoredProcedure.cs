﻿using System.Data;
using System.Data.Common;
using DosPinos.HRMS.Entities.Enums.Commons;
using DosPinos.HRMS.Entities.Interfaces.Commons.Base;
using DosPinos.HRMS.Entities.ValueObjects;

namespace DosPinos.HRMS.EFCore.Repositories.Commons.Base
{
    internal abstract class BaseStoredProcedure(DospinosdbContext context)
    {
        private readonly DospinosdbContext _context = context;

        public DbCommand CreateCommand(string storedProcedureName, Dictionary<string, object> parameters)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        var dbParameter = command.CreateParameter();
                        dbParameter.ParameterName = param.Key;
                        dbParameter.Value = param.Value ?? DBNull.Value;
                        command.Parameters.Add(dbParameter);
                    }
                }
                return command;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Dictionary<string, object>>> ExecuteReadAsync(DbCommand command)
        {
            try
            {
                List<Dictionary<string, object>> result = [];

                using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var row = new Dictionary<string, object>();
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                    }
                    result.Add(row);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IOperationResponseVO> ExecuteWriteAsync(DbCommand command)
        {
            try
            {
                IOperationResponseVO response = new OperationResponseVO();

                using var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var messageId = reader["Message_ID"] as int?;
                    var message = reader["Message"] as string;

                    // Setting the status based on the message ID
                    response.Status = messageId.HasValue ? (ResponseStatus)messageId.Value : ResponseStatus.Error;
                    response.Message = [message];
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}