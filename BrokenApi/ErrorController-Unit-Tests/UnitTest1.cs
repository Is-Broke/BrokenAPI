using System;
using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BrokenApi.Data;
using BrokenApi.Models;
using BrokenApi.Controllers;

namespace ErrorController_Unit_Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void DatabaseCanSave()
        {
            DbContextOptions<BrokenAPIContext> options =
                new DbContextOptionsBuilder<BrokenAPIContext>()
                .UseInMemoryDatabase("DbCanSave")
                .Options;

            using (BrokenAPIContext context = new BrokenAPIContext(options))
            {
                // Arrange
                Error newError = new Error
                {
                    ErrorCategoryID = 0,
                    DetailedName = "testError",
                    Description = "This is a test.",
                    Link = "test",
                    CodeExample = "test",
                    IsUserExample = false,
                    Votes = 0,
                    Rating = 0
                };

                // Act
                await context.Errors.AddAsync(newError);
                await context.SaveChangesAsync();

                var results = context.Errors.Where(e => e.DetailedName == "testError");

                // Assert
                Assert.Equal(1, results.Count());
            }
        }

        [Fact]
        public async void PostErrorCanCreateNewErrors()
        {
            DbContextOptions<BrokenAPIContext> options =
                new DbContextOptionsBuilder<BrokenAPIContext>()
                .UseInMemoryDatabase("DbCanSave")
                .Options;

            using (BrokenAPIContext context = new BrokenAPIContext(options))
            {
                // Arrange
                ErrorController ec = new ErrorController(context);

                Error newError = new Error
                {
                    ErrorCategoryID = 0,
                    DetailedName = "postTest",
                    Description = "This is a test of the Post method.",
                    Link = "test",
                    CodeExample = "test",
                    IsUserExample = false,
                    Votes = 0,
                    Rating = 0
                };

                // Act
                await ec.PostError(newError);

                var results = context.Errors.Where(e => e.DetailedName == "postTest");

                // Assert
                Assert.Equal(1, results.Count());
            }
        }
        

    }
}
