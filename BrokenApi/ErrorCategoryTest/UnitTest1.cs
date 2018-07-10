using System;
using Xunit;
using Moq;
using BrokenApi.Data;
using BrokenApi.Controllers;
using System.Threading.Tasks;
using System.Collections.Generic;
using BrokenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ErrorCategoryTest
{
    public class UnitTest1
    {

        [Fact]
        public async Task GetAllCategoriesAsyncTest()
        {
            var Categories = GetErrorCategoriesForTest();
            var mockContext = new Mock<BrokenAPIContext>();
            
            var testControler = new ErrorCategoryController();
            
            mockContext.Setup(x => x.Categories)
           
        }

        private List<ErrorCategory> GetErrorCategoriesForTest()
        {
            List<ErrorCategory> testCategorylist = new List<ErrorCategory>();
            ErrorCategory test1 = new ErrorCategory {ID = 1, Description = "test1", ErrorType = "firstTestObj" };
            ErrorCategory test2 = new ErrorCategory {ID = 2, Description = "test2", ErrorType = "secondTestObj" };
            ErrorCategory test3 = new ErrorCategory { ID = 3, Description = "test3", ErrorType = "thridTestObj" };
            ErrorCategory test4 = new ErrorCategory { ID = 4, Description = "test4", ErrorType = "fourthTestObj" };
            testCategorylist.Add(test1);
            testCategorylist.Add(test2);
            testCategorylist.Add(test3);
            testCategorylist.Add(test4);

            return testCategorylist;
        }
    }

}
