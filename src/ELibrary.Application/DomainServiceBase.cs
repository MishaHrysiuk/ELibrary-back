using Abp.Domain.Services;

namespace ELibrary
{
    public class DomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */
        protected DomainServiceBase()
        {
            LocalizationSourceName = ELibraryConsts.LocalizationSourceName;
        }
    }
}
