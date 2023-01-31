using System.Collections.Generic;
using Abp.Application.Services;
using ELibrary.Auditing.Dto;
using ELibrary.Shared.Dto;

namespace ELibrary.Auditing
{
    public interface IAuditLogExcelAppService : IApplicationService
    {
        FileDto ExportAuditLogsToFile(List<AuditLogListDto> auditLogList);

        FileDto ExportEntityChangesToFile(List<EntityChangeListDto> auditLogList);
    }
}
