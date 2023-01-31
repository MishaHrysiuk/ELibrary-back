using System.Threading.Tasks;
using ELibrary.Models.TokenAuth;
using ELibrary.Web.Controllers;
using Shouldly;
using Xunit;

namespace ELibrary.Web.Tests.Controllers
{
    public class HomeController_Tests: ELibraryWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}