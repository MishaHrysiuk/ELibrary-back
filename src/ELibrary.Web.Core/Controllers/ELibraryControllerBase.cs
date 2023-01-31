using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ELibrary.Controllers
{
    public abstract class ELibraryControllerBase: AbpController
    {
        protected ELibraryControllerBase()
        {
            LocalizationSourceName = ELibraryConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
