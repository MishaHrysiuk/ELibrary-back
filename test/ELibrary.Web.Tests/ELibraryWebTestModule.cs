using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ELibrary.EntityFrameworkCore;
using ELibrary.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ELibrary.Web.Tests
{
    [DependsOn(
        typeof(ELibraryWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ELibraryWebTestModule : AbpModule
    {
        public ELibraryWebTestModule(ELibraryEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ELibraryWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ELibraryWebMvcModule).Assembly);
        }
    }
}