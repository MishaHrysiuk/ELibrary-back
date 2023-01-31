using Abp.Auditing;
using Abp.EntityHistory;
using AutoMapper;

namespace ELibrary.Auditing.Dto
{
    internal class AuditLogMapProfile : Profile
    {
        public AuditLogMapProfile()
        {
            // Audit Logs
            CreateMap<AuditLogAndUser, AuditLogListDto>();
            CreateMap<AuditLog, AuditLogListDto>();

            // Entity Changes
            CreateMap<EntityChange, EntityChangeListDto>();
            CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();
        }
    }
}
