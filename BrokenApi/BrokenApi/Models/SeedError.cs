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
                        ErrorCategoryID = 0,
                        DetailedName = "Unexpected Output string",
                        Link = "",
                        CodeExample = $"public static void Main(string[] args)" +
        $"{{" +
            $"Console.WriteLine(\"Hello World\");" +
            $"string firstName = \"John\";" +
            $"string lastName = \"Doe\";" +
            $"MakeFullName(firstName, lastName);" +
        $"}}" +
        $"public static void MakeFullName(string one, string two)" +
        $"{{" +
            $"Console.WriteLine(one + two);  // output is JohnDoe" +

            $"Console.WriteLine(one + \" \" + two); //Correct output of John Doe" +
            $"Console.WriteLine($\"{{one}} {{two}}\"); // same as above" +
        $"}}",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "Error still computes but makes undesired output"

                    },
                     new Error
                     {
                         ErrorCategoryID = 0,
                         DetailedName = "Unexpected Output Int",
                         Link = "",
                         CodeExample = $"public static void Main(string[] args)" +
        $"{{" +
            $"Console.WriteLine(\"Hello World\");" +
           $"Console.WriteLine(FindAverage(20, 12));" +
            $"Console.WriteLine(FindAverageTrue(20, 12));" +
        $"}}" +
        $"public static int FindAverage(int x, int y)" +
       $"{{" +
            $"return x + y / 2;   // return 26 wrong output for average wanted 16" +
        $"}}" +

        $"public static int FindAverageTrue(int x, int y)" +
        $"{{" +
            $"return (x + y) / 2;  // returned the correct output for average" +
        $"}}" +
    $"}}",
                         IsUserExample = false,
                         Votes = 0,
                         Rating = 0,
                         Description = $"Error will compute but is not the desired output"

                     },
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
                        Votes = 0,
                        Rating = 0,
                    },


                    new Error
                    {
                        ErrorCategoryID = 1,
                        CodeExample = "int quotient = 5 / 0;",
                        DetailedName = "Divide By Zero",
                        Votes = 1,
                        Rating = 0,
                    },

                    new Error
                    {
                        ErrorCategoryID = 2,
                        CodeExample = "if (x = y)\n" +
                                      "{\n" +
                                      "\tdo something\n" +
                                      "}",
                        DetailedName = "Invalid Conversion",
                        Votes = 0,
                        Rating = 0,
                    });

                await context.SaveChangesAsync();
            }
        }
    }
}
