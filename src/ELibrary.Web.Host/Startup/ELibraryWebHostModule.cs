using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ELibrary.Configuration;

namespace ELibrary.Web.Host.Startup
{
    [DependsOn(
       typeof(ELibraryWebCoreModule))]
    public class ELibraryWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ELibraryWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ELibraryWebHostModule).GetAssembly());
        }
    }
}
