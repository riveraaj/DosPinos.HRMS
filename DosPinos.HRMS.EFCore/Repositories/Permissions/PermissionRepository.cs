using DosPinos.HRMS.BusinessObjects.Interfaces.Permissions;
using DosPinos.HRMS.Entities.DTOs.Permissions;

namespace DosPinos.HRMS.EFCore.Repositories.Permissions
{
    internal class PermissionRepository(DospinosdbContext context,
                                   IInvokeStoredProcedure invokeSP) : IPermissionRepository
    {
        private readonly DospinosdbContext _context = context;
        private readonly IInvokeStoredProcedure _invokeSP = invokeSP;

        public async Task<IOperationResponseVO> CreateAsync(CreatePermissionDTO permission)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@dateStart", permission.DateStart},
                {"@dateEnd", permission.DateEnd},
                {"@documentationPath", permission.DocumentationPath},
                {"@employeeId", permission.EmployeeId},
                {"@permissionType", permission.PermissionTypeId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateSpecialPermission", parameters, false);
        }

        public async Task<(bool, string)> DeleteAsync(int permissionId)
        {
            SpecialPermission permission = await _context.SpecialPermissions.FindAsync(permissionId);

            if (permission == null) return (false, string.Empty);
            string documentationPath = permission.DocumentationPath;

            _context.SpecialPermissions.Remove(permission);

            int affectedRows = await _context.SaveChangesAsync();
            return (affectedRows > 0, documentationPath);
        }

        public async Task<IOperationResponseVO> EvaluateAsync(EvaluatePermissionDTO permissionDTO)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@isApproved", permissionDTO.IsApproved},
                {"@employeeId", permissionDTO.EmployeeId},
                {"@permissionId", permissionDTO.PermissionId},
            };

            return await _invokeSP.ExecuteAsync("[humanresources].usp_CreateEvaluationSpecialPermission", parameters, false);
        }

        public async Task<IEnumerable<GetAllPermissionByEmployeeDTO>> GetAllAsync(int identification)
        {
            Dictionary<string, object> parameters = new()
            {
                {"@identification", identification}
            };

            var result = await _invokeSP.ExecuteAsync("[humanresources].usp_GetAllPermissionByIdentification", parameters, true);

            List<GetAllPermissionByEmployeeDTO> permissions = [];

            foreach (var row in (List<Dictionary<string, object>>)result.Content)
            {
                permissions.Add(new GetAllPermissionByEmployeeDTO()
                {
                    EmployeeId = row.TryGetValue("employee_id", out object employeeId) ? Convert.ToInt32(employeeId) : 0,
                    PermissionId = row.TryGetValue("special_permission_id", out object permissionId) ? Convert.ToInt32(permissionId) : 0,
                    TypePermission = row.TryGetValue("special_permission_type_description", out object typePermission) ? typePermission.ToString() : string.Empty,
                    EndDate = row.TryGetValue("date_end", out object endPeriod) && endPeriod != DBNull.Value
                        ? DateOnly.Parse(((DateTime)endPeriod).ToString("yyyy-MM-dd"))
                        : default,
                    StartDate = row.TryGetValue("date_start", out object startPeriod) && startPeriod != DBNull.Value
                        ? DateOnly.Parse(((DateTime)startPeriod).ToString("yyyy-MM-dd"))
                        : default,
                    Days = row.TryGetValue("days", out object days) ? Convert.ToInt32(days) : 0,
                    Status = row.TryGetValue("status", out object status) ? status.ToString() : string.Empty,
                    DocumentationPath = row.TryGetValue("documentation_path", out object path) ? path.ToString() : string.Empty,
                });
            }

            return permissions;
        }

        public async Task<bool> UpdateAsync(UpdatePermissionDTO permissionDTO)
        {
            SpecialPermission permission = await _context.SpecialPermissions.FindAsync(permissionDTO.PermissionId);

            if (permission == null) return false;

            permission.DateStart = permissionDTO.DateStart;
            permission.DateEnd = permissionDTO.DateEnd;
            permission.DocumentationPath = permissionDTO.DocumentationPath;

            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}