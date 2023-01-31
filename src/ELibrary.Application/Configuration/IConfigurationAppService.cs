using System.Threading.Tasks;
using ELibrary.Configuration.Dto;

namespace ELibrary.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
