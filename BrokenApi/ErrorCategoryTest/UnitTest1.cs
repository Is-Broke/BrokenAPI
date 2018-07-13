using System;
using Xunit;
using Moq;
using BrokenApi.Data;
using BrokenApi.Controllers;
using System.Threading.Tasks;
using System.Collections.Generic;
using BrokenApi.Models;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using System.Collections;
using System.Linq;

namespace ErrorCategoryTest
{
   
    public class UnitTest1
    {

        [Fact]
        public async void GetAllCategoriesAsyncAsList()
        {

            DbContextOptions<BrokenAPIContext> options =
                new DbContextOptionsBuilder<BrokenAPIContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;

            using (BrokenAPIContext context = new BrokenAPIContext(options))
            {
                var TestController = new ErrorCategoryController(context);

                await context.Categories.AddRangeAsync(
                new ErrorCategory { ID = 1, Description = "test1", ErrorType = "firstTestObj" },
                new ErrorCategory { ID = 2, Description = "test2", ErrorType = "Syntax" },
                new ErrorCategory { ID = 3, Description = "test3", ErrorType = "Runtime" },
                new ErrorCategory { ID = 4, Description = "test4", ErrorType = "fourthTestObj" });

                await context.SaveChangesAsync();

                var allCategory = TestController.GetAllCategories();

                await Assert.IsType<Task<List<ErrorCategory>>>(allCategory);
                Assert.Equal(4, allCategory.Result.Count());
            }        
        }

       

        [Fact]
        public async void GetOneCategoryTest()
        {
            DbContextOptions<BrokenAPIContext> options =
                new DbContextOptionsBuilder<BrokenAPIContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;

            using (BrokenAPIContext context = new BrokenAPIContext(options))
            {
                var TestController = new ErrorCategoryController(context);

                var OneCategoryResult = TestController.GetOneCategory("Syntax");

                Assert.Equal(1, OneCategoryResult.Id);
            }
        }

        [Fact]
        public async void GetOneCategoryAndErrorTest()
        {

            DbContextOptions<BrokenAPIContext> options =
                new DbContextOptionsBuilder<BrokenAPIContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;

            using (BrokenAPIContext context = new BrokenAPIContext(options))
            {

                var TestController = new ErrorCategoryController(context);
                var TestErrorController = new ErrorController(context);

                ArrayList testList = new ArrayList();

                await context.Errors.AddRangeAsync(
                    new Error
                    {
                        ErrorCategoryID = 2,
                        DetailedName = "Invalid Assignment",
                        CodeExample =
                        "public static void Main(String[] args)\n",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "Error1"
                    }, new Error
                    {
                        ErrorCategoryID = 2,
                        DetailedName = "Test 2",
                        CodeExample =
                        "\t}\n" +
                        "}",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "Errortest"
                    
                    });

                var OneCategoryAndErrorResult = await TestController.GetAllTypeError("syntax");//test method

                var OneErrorTest = await context.Errors.Where(a => a.ID == 2).ToListAsync();//set error to test on
                var OneTestCategory = context.Categories.Where(c => c.ErrorType == "syntax");//set category

                testList.Add(OneCategoryAndErrorResult);
                testList.Add(OneErrorTest);

                Assert.Equal(OneErrorTest, OneCategoryAndErrorResult[1]);//check to make sure result is expected outcome
                Assert.IsType<ArrayList>(OneCategoryAndErrorResult);//check to make sure array is returned
             
            }


        }

        /// <summary>
        /// test for all elements getting through with the 4 categories added from test 1
        /// 2 elements getting added in test 3,  and 2 more elements getting added in this test,
        /// makes the total returned elements should be 8
        /// </summary>
        [Fact]
        public async void getAllCategoryAndErrorTest()
        {

            DbContextOptions<BrokenAPIContext> options =
                new DbContextOptionsBuilder<BrokenAPIContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;

            using (BrokenAPIContext context = new BrokenAPIContext(options))
            {

                var TestController = new ErrorCategoryController(context);
                var TestErrorController = new ErrorController(context);

                ArrayList testList = new ArrayList();

                await context.Errors.AddRangeAsync(
                    new Error
                    {
                        ErrorCategoryID = 2,
                        DetailedName = "Invalid Assignment",
                        CodeExample =
                        "public static void Main(String[] args)\n" +
                        "{\n" +
                        "\tif (x = y)\n" +
                        "\t{\n" +
                        "\t\tConsole.WriteLine(x)\n" +
                        "\t}\n" +
                        "}",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "Error occurs when erroneously attempting to assign " +
                                      "values when doing a comparison, such as in an \"if statement\"."
                    },new Error
                    {
                        ErrorCategoryID = 1,
                        DetailedName = "Test 2",
                        CodeExample =
                        "\t}\n" +
                        "}",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "Errortest"

                    });

                var OneCategoryAndErrorResult = await TestController.GetAllTypesAndError();
                var OneErrorTestType2 = await context.Errors.Where(a => a.ID == 2).ToListAsync();

                testList.Add(OneCategoryAndErrorResult[0]);
                testList.Add(OneErrorTestType2);

                Assert.Equal(8, OneCategoryAndErrorResult.Capacity);//8 because first test adds 4 categories, 3rd test adds 2 errors and this one adds 2 more for total of 8.

            }
            }
    }

}
