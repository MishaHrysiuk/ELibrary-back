using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ELibrary.Authorization;

namespace ELibrary
{
    [DependsOn(
        typeof(ELibraryCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ELibraryApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ELibraryAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ELibraryApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
