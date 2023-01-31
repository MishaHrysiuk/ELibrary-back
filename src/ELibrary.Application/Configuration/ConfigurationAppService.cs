using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ELibrary.Configuration.Dto;

namespace ELibrary.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ELibraryAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
