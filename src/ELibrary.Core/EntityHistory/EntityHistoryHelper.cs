using System;
using System.Linq;
using ELibrary.Authorization.Roles;
using ELibrary.Authorization.Users;
using ELibrary.MultiTenancy;

namespace ELibrary.EntityHistory
{
    public static class EntityHistoryHelper
    {
        public const string EntityHistoryConfigurationName = "EntityHistory";

        public static readonly Type[] HostSideTrackedTypes =
        {
            typeof(Role), 
            typeof(Tenant),
            typeof(User)
        };

        public static readonly Type[] TenantSideTrackedTypes =
        {
            typeof(Role),
            typeof(Tenant),
            typeof(User)
        };

        public static readonly Type[] TrackedTypes =
            HostSideTrackedTypes
                .Concat(TenantSideTrackedTypes)
                .GroupBy(type => type.FullName)
                .Select(types => types.First())
                .ToArray();
    }
}
