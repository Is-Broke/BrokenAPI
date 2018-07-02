using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BrokenApi.Data;

namespace BrokenApi.Models
{
    public class SeedCategory
    {

        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BrokenAPIContext(
                serviceProvider.GetRequiredService<DbContextOptions<BrokenAPIContext>>()))
            {
                if (context.Categories.Any())
                {
                    return;
                }

                await context.Categories.AddRangeAsync(
                    new ErrorCategory
                    {

                        ErrorType = (ErrorType)0,
                        Description = "Logic Error",
                    },
                    new ErrorCategory
                    {

                        ErrorType = (ErrorType)1,
                        Description = "Run-Time Error",
                    },
                    new ErrorCategory
                    {

                        ErrorType = (ErrorType)2,
                        Description = "Syntax Error",
                    });
                await context.SaveChangesAsync();
            }
        }
    }
}
