using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Bunit;
using Reservations_system.Components;

namespace Test_ReservationsSystem.Test_Components
{
    public class AdminHomePageTests
    {
        [Fact]
        public void TestEditModeValue()
        {
            using var ctx = new TestContext();
            var componentTest = ctx.RenderComponent<AdminHomePage>().Instance;


            var expectedEditModeValue = false;

            var actualEditModeValue = componentTest.editMode;

            Assert.Equal(expectedEditModeValue, actualEditModeValue);
        }

        [Fact]
        public void PrintNothing()
        {
            string dum = "yes";
            Assert.Equal("yes", dum);
        }
    }
}
