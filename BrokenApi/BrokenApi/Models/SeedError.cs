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
                        Link = "https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/error-types",
                        CodeExample = $"public static void Main(string[] args) {{\n" +
                        $"\t string firstName = \"John\"; \n" +
                        $"\t string lastName = \"Doe\"; \n" +
                        $"\t MakeFullName(firstName, lastName); \n" +
                        $"}} \n" +
                        $"public static void MakeFullName(string one, string two){{ \n" +
                        $"\t Console.WriteLine(one + two);  // output is JohnDoe when desired output should be John Doe\n" +
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
                         Link = "https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/error-types",
                         CodeExample = $"public static void Main(string[] args){{ \n" +
                         $"\t Console.WriteLine(FindAverage(20, 12)); \n" +
                         $"}}\n" +
                         $"public static int FindAverage(int x, int y){{ \n" +
                         $"\t return x + y / 2;   // return 26 wrong output for average, wanted 16\n" +
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
                    },
                    new Error
                    {
                        ErrorCategoryID = 2,
                        CodeExample = " b = (4 + 6;  // missing closing parenthesis, ')' expected",
                        DetailedName = "Missing closing parenthesis",
                        Votes = 0,
                        Rating = 0,
                        Description = "forgot to close parenthesis",
                        IsUserExample = false,
                        Link = ""
                    },
                    new Error
                    {
                        ErrorCategoryID = 2,
                        CodeExample = " b = 5 + * 9;   // missing argument between + and *",
                        DetailedName = "missing argument",
                        Votes = 0,
                        Rating = 0,
                        Description = "Missing something between the addition and multiply signs.",
                        IsUserExample = false,
                        Link = "https://msdn.microsoft.com/en-us/library/system.argumentexception(v=vs.110).aspx"
                    },
                    new Error
                    {
                        ErrorCategoryID = 2,
                        CodeExample = $"int i; \n" +
                        $"i++    // use of unassigned local variable 'i' ",
                        DetailedName = "not initialized",
                        Votes = 0,
                        Rating = 0,
                        Description = "Semantic Error where variable is not initialized",
                        IsUserExample = false,
                        Link = ""
                    },
                    new Error
                    {
                        ErrorCategoryID = 2,
                        CodeExample = "int a = \"John\";  // Cannot implicitly convert type 'string' to 'int'",
                        DetailedName = "Type incompatibility",
                        Votes = 0,
                        Rating = 0,
                        Description = "the types string and int are not compatible",
                        IsUserExample = false,
                        Link = "https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/casting-and-type-conversions",
                    },
                    new Error
                    {
                        ErrorCategoryID = 1,
                        CodeExample = $"int[] myarray = new int[10];\n" +
                         $" myarray[5] = 5; \n" +
                         $" myarray[10] = 10;\n" +
                         $"Console.WriteLine(myarray);",
                        DetailedName = "System.IndexOutOfRangeException",
                        Votes = 0,
                        Rating = 0,
                        Description = " 'Index was outside the bounds of the array.'",
                        IsUserExample = false,
                        Link = "https://docs.microsoft.com/en-us/dotnet/api/system.indexoutofrangeexception?view=netframework-4.7.1"
                    },
                    new Error
                    {
                        ErrorCategoryID = 0,
                        CodeExample = $"string x = Console.ReadLine(); \n" +
                        $"while (x != null){{\n" +
                        $"Console.WriteLine(x);\n" +
                        $"}}",
                        DetailedName = "Loop doesn't Terminate",
                        Votes = 0,
                        Rating = 0,
                        Description = "Constantly prints to console with loop that doesn't end.",
                        IsUserExample = false,
                        Link = "https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/error-types"
                    },
                    new Error
                    {

                    },
                    new Error
                    {
                        ErrorCategoryID = 1,
                        CodeExample = "using (StreamReader sr = new StreamReader(path: \"../somthing.txt\"));",
                        DetailedName = "System.IO.FileNotFoundException",
                        Votes = 0,
                        Rating = 0,
                        Description = "if file is not on in path throws file not found",
                        IsUserExample = false,
                        Link = "https://docs.microsoft.com/en-us/dotnet/api/system.io.filenotfoundexception?view=netframework-4.7.1"
                    },
                    new Error
                    {
                        ErrorCategoryID = 2,
                        CodeExample = "int a = 5   // semicolon is missing, ';' expected",
                        DetailedName = "Missing semicolon",
                        Votes = 0,
                        Rating = 0,
                        Description = "Forgetting to put semicolon after statement",
                        IsUserExample = false,
                        Link = ""  
                    });

                await context.SaveChangesAsync();
            }
        }
    }
}
