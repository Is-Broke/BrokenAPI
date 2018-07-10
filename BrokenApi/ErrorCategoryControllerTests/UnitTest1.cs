using BrokenApi.Controllers;
using System;
using Xunit;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace ErrorCategoryControllerTests
{
    public class UnitTest1
    {
        [TestFixture]
        [Fact]
        public void TestGetAll()
        {
            var controller = new ErrorCategoryController(context);

        }
    }
}
