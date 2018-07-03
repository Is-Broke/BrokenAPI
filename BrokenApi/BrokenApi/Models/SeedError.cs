using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BrokenApi.Data;

namespace BrokenApi.Models
{
    public class SeedError
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BrokenAPIContext(
                serviceProvider.GetRequiredService<DbContextOptions<BrokenAPIContext>>()))
            {
                if (context.Errors.Any())
                {
                    return;
                }

                await context.Errors.AddRangeAsync(
                    new Error
                    {
                        ErrorCategoryID = 1,
                        DetailedName = "NullReference Exception",
                        Link = "https://docs.microsoft.com/en-us/dotnet/api/system.nullreferenceexception?view=netframework-4.7.2",
                        CodeExample =
                        "public static void Main(String[] args)\n" +
                        "{\n" +
                        "\tStack myStack = new Stack();\n" +
                        "\tFindTopOfStack(myStack);\n" +
                        "}\n" +
                        "public static Node FindTopOfStack(Stack inputStack)\n" +
                        "{\n" +
                        "\tNode formerTop = inputStack.Pop();\n" +
                        "\treturn formerTop;\n" +
                        "}",
                        IsUserExample = false,
                        Votes = 0
                    },


                    new Error
                    {
                        ErrorCategoryID = 1,
                        CodeExample = "int quotient = 5 / 0;",
                        DetailedName = "Divide By Zero",
                        Votes = 1
                    },

                    new Error
                    {
                        ErrorCategoryID = 2,
                        CodeExample = "if (x = y)\n" +
                                      "{\n" +
                                      "\tdo something\n" +
                                      "}",
                        DetailedName = "Invalid Conversion",
                        Votes = 0
                    });

                await context.SaveChangesAsync();
            }
        }
    }
}
