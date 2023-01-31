using Abp.Authorization;
using ELibrary.Authorization.Roles;
using ELibrary.Authorization.Users;

namespace ELibrary.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
