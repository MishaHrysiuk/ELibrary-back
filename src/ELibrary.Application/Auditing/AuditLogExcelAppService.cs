using System.Collections.Generic;
using System.IO;
using System.Linq;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Extensions;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using ClosedXML.Excel;
using ELibrary.Auditing.Dto;
using ELibrary.Authorization;
using ELibrary.Net.MimeTypes;
using ELibrary.Shared.Dto;

namespace ELibrary.Auditing
{
    [DisableAuditing]
    [AbpAuthorize(PermissionNames.Pages_AuditLogs)]
    public class AuditLogExcelAppService : DomainServiceBase, IAuditLogExcelAppService
    {
        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        private const string EXCEL_CONTENT_EXTENSION = ".xlsx";
        private const double CELL_TIME_WIDTH = 15;
        private const double CELL_HEIGHT = 15;
        private const double CELL_ERROR_STATE_WIDTH = 35;

        //For more info on how to use it visit https://github.com/ClosedXML/ClosedXML/wiki

        public AuditLogExcelAppService(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
            LocalizationSourceName = ELibraryConsts.LocalizationSourceName;
        }

        public FileDto ExportAuditLogsToFile(List<AuditLogListDto> auditLogList)
        {
            var orderedAuditLogList = auditLogList
                .OrderByDescending(x => x.ExecutionTime)
                .ToList();

            IXLWorkbook workbook = new XLWorkbook();

            IXLWorksheet worksheet = workbook.Worksheets.Add(L("OperationLogs"));

            //Make headers starting from A1, B1, etc...
            worksheet.Cell("A1").Value = L("Time");
            worksheet.Cell("B1").Value = L("UserName");
            worksheet.Cell("C1").Value = L("Service");
            worksheet.Cell("D1").Value = L("Action");
            worksheet.Cell("E1").Value = L("Parameters");
            worksheet.Cell("F1").Value = L("Duration");
            worksheet.Cell("G1").Value = L("IpAddress");
            worksheet.Cell("H1").Value = L("Client");
            worksheet.Cell("I1").Value = L("Browser");
            worksheet.Cell("J1").Value = L("ErrorState");

            //Add some styles to headers
            var worksheetHeaders = worksheet.RangeUsed();
            worksheetHeaders.Style.Font.Bold = true;
            worksheetHeaders.Style.Fill.BackgroundColor = XLColor.Cyan;

            var index = 2;

            foreach (var auditLog in orderedAuditLogList)
            {
                //Start filling from Value A2, B2, etc...
                worksheet.Cell($"A{index}").Value = _timeZoneConverter.Convert(auditLog.ExecutionTime, _abpSession.TenantId, _abpSession.GetUserId());
                worksheet.Cell($"B{index}").Value = auditLog.UserName;
                worksheet.Cell($"C{index}").Value = auditLog.ServiceName;
                worksheet.Cell($"D{index}").Value = auditLog.MethodName;
                worksheet.Cell($"E{index}").Value = auditLog.Parameters;
                worksheet.Cell($"F{index}").Value = auditLog.ExecutionDuration;
                worksheet.Cell($"G{index}").Value = auditLog.ClientIpAddress;
                worksheet.Cell($"H{index}").Value = auditLog.ClientName;
                worksheet.Cell($"I{index}").Value = auditLog.BrowserInfo;
                worksheet.Cell($"J{index}").Value = auditLog.Exception.IsNullOrEmpty() ? L("Success") : auditLog.Exception;
                index++;
            }

            //Adjust rows and columns according to content
            worksheet.Cells().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            worksheet.Column("A").Width = CELL_TIME_WIDTH;
            worksheet.Column("J").Width = CELL_ERROR_STATE_WIDTH;
            worksheet.Rows().Height = CELL_HEIGHT;

            using (MemoryStream stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return new FileDto
                {
                    Context = stream.ToArray(),
                    FileName = L("OperationLogs") + EXCEL_CONTENT_EXTENSION,
                    FileType = MimeTypeNames.ApplicationVndOpenxmlformatsOfficedocumentSpreadsheetmlSheet
                };
            }
        }

        public FileDto ExportEntityChangesToFile(List<EntityChangeListDto> entityChangeList)
        {
            var orderedEntityChangeList = entityChangeList
                .OrderByDescending(x => x.ChangeTime)
                .ToList();

            IXLWorkbook workbook = new XLWorkbook();

            IXLWorksheet worksheet = workbook.Worksheets.Add(L("ChangeLogs"));

            //Make headers starting from A1, B1, etc...
            worksheet.Cell("A1").Value = L("Time");
            worksheet.Cell("B1").Value = L("Action");
            worksheet.Cell("C1").Value = L("UserName");
            worksheet.Cell("D1").Value = L("Object");

            //Add some styles to headers
            var worksheetHeaders = worksheet.RangeUsed();
            worksheetHeaders.Style.Font.Bold = true;
            worksheetHeaders.Style.Fill.BackgroundColor = XLColor.Cyan;

            var index = 2;

            foreach (var entityChange in orderedEntityChangeList)
            {
                //Start filling from Value A2, B2, etc...
                worksheet.Cell($"A{index}").Value = _timeZoneConverter.Convert(entityChange.ChangeTime, _abpSession.TenantId, _abpSession.GetUserId());
                worksheet.Cell($"B{index}").Value = entityChange.ChangeType.ToString();
                worksheet.Cell($"C{index}").Value = entityChange.UserName;
                worksheet.Cell($"D{index}").Value = entityChange.EntityTypeFullName;
                index++;
            }

            //Adjust rows and columns according to content
            worksheet.Cells().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            worksheet.Column("A").Width = CELL_TIME_WIDTH;

            using (MemoryStream stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return new FileDto
                {
                    Context = stream.ToArray(),
                    FileName = L("ChangeLogs") + EXCEL_CONTENT_EXTENSION,
                    FileType = MimeTypeNames.ApplicationVndOpenxmlformatsOfficedocumentSpreadsheetmlSheet
                };
            }
        }
    }
}
