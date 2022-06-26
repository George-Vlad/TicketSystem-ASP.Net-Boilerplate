using System.Threading.Tasks;
using GeorgeVlad.TicketingSystem.Models.TokenAuth;
using GeorgeVlad.TicketingSystem.Web.Controllers;
using Shouldly;
using Xunit;

namespace GeorgeVlad.TicketingSystem.Web.Tests.Controllers
{
    public class HomeController_Tests: TicketingSystemWebTestBase
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