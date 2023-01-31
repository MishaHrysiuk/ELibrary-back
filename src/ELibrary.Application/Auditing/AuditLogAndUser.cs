using Abp.Auditing;
using ELibrary.Authorization.Users;

namespace ELibrary.Auditing
{
    public class AuditLogAndUser
    {
        public AuditLog AuditLog { get; set; }

        public User User { get; set; }
    }
}
