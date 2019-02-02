using System;
using Volvo.Controllers;
using Xunit;
using TruckServices = Volvo.Services.Interface;

namespace VolvoTest
{
    public class ControllerTest
    {
        private readonly Volvo.Services.TruckServices _iTruckServices;

        public ControllerTest(Volvo.Services.TruckServices itruckServices)
        {
            _iTruckServices = itruckServices;
        }

        [Fact]
        public void GetViewResultHomeController()
        {
            var controller = new HomeController();
            var result = controller.About().ToString();
            Assert.Equal("Microsoft.AspNetCore.Mvc.ViewResult", result);
        }

        [Fact]
        public void GetTruckById()
        {
            var controller = new TruckController(_iTruckServices);
            var result = controller.GetTruckById(new Guid("e4d330dc-f256-4a95-94b6-b10d045e65a9"));
            Assert.Equal("Ok", result.ToString());
        }
    }
}
