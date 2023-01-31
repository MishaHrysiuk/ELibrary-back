using Abp.EntityHistory;
using ELibrary.Authorization.Users;

namespace ELibrary.Auditing
{
    public class EntityChangeAndUser
    {
        public EntityChange EntityChange { get; set; }

        public User User { get; set; }
    }
}
