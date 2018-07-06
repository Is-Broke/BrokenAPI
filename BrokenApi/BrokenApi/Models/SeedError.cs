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
                        CodeExample = 
                        "public static void Main(string[] args)\n" +
                        "{\n" +
                        "\tConsole.WriteLine(\"Hello World\");\n" +
                        "\tstring firstName = \"John\";\n" +
                        "\tstring lastName = \"Doe\";\n" +
                        "\tMakeFullName(firstName, lastName);\n" +
                        "}\n" +
                        "public static void MakeFullName(string one, string two)\n" +
                        "{\n" +
                        "\tConsole.WriteLine(one + two);  // output is JohnDoe\n" +
                        "\tConsole.WriteLine(one + \" \" + two); //Correct output of John Doe\n" +
                        "\tConsole.WriteLine($\"{one} {two}\"); // same as above\n" +
                        "}",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "Error still computes but makes undesired output."
                    },

                     new Error
                     {
                         ErrorCategoryID = 0,
                         DetailedName = "Unexpected Output Int",
                         Link = "https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/error-types",
                         CodeExample =
                         "public static void Main(string[] args)\n" +
                         "{\n" +
                         "\tConsole.WriteLine(\"Hello World\");\n" +
                         "\tConsole.WriteLine(FindAverage(20, 12));\n" +
                         "\tConsole.WriteLine(FindAverageTrue(20, 12));\n" +
                         "}\n" +
                         "public static int FindAverage(int x, int y)\n" +
                         "{\n" +
                         "\treturn x + y / 2;   // returns 26 instead of the expected output of 16\n" +
                         "}\n" +
                         "public static int FindAverageTrue(int x, int y)\n" +
                         "{\n" +
                         "\treturn (x + y) / 2;  // returned the correct output for average\n" +
                         "}",
                         IsUserExample = false,
                         Votes = 0,
                         Rating = 0,
                         Description = "Error will compute but does not produce is not the expected output."
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
                        Description = "Error occurs when a method is passed a null argument, " +
                                      "and is unable to handle null input. This Error typically " +
                                      "causes the application to stop functioning."
                    },
                    
                    new Error
                    {
                        ErrorCategoryID = 1,
                        DetailedName = "DivideByZero Exception",
                        Link = "https://msdn.microsoft.com/en-us/library/system.dividebyzeroexception(v=vs.110).aspx",
                        CodeExample =
                        "public static void Main(String[] args)\n" +
                        "{\n" +
                        "\tint quotient = 5 / 0;" +
                        "\tConsole.WriteLine(quotient)" +
                        "}",
                        IsUserExample = false,
                        Votes = 1,
                        Rating = 0,
                        Description = "Error occurs when trying to divide a number by zero. " +
                                      "Since this is mathematically impossible, this error typically " +
                                      "causes the application to stop functioning."
                    },

                    new Error
                    {
                        ErrorCategoryID = 2,
                        DetailedName = "Invalid Assignment",
                        CodeExample =
                        "if (x = y)\n" +
                        "{\n" +
                        "\tConsole.WriteLine(x)\n" +
                        "}",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "Error occurs when erroneously attempting to assign " +
                                      "values when doing a comparison, such as in an \"if statement\"."
                    },

                    new Error
                    {
                        ErrorCategoryID = 2,
                        DetailedName = "Missing Parenthesis",
                        CodeExample =
                        "public static void Main(String[] args)\n" +
                        "{\n" +
                        "\tb = (4 + 6;  // missing closing parenthesis, ')' expected\n" +
                        "}",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "Error caused by not providing an opening or " +
                                      "closing parenthesis to a statement."
                    },

                    new Error
                    {
                        ErrorCategoryID = 2,
                        DetailedName = "missing argument",
                        Link = "https://msdn.microsoft.com/en-us/library/system.argumentexception(v=vs.110).aspx",
                        CodeExample =
                        "public static void Main(String[] args)\n" +
                        "{\n" +
                        "\tb = 5 + * 9;   // missing argument between + and *\n" +
                        "}",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "Missing and operand between two operators " +
                        "(addition and multiplication signs)."
                    },

                    new Error
                    {
                        ErrorCategoryID = 2,
                        DetailedName = "Invalid Initializer",
                        CodeExample =
                        "public static void Main(String[] args)\n" +
                        "{\n" +
                        "\ti++ // use of undefined local variable 'i'\n" +
                        "}",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "Error caused when attempting to perform on operation " +
                                      "using a variable which has not been previously declared."
                    },

                    new Error
                    {
                        ErrorCategoryID = 2,
                        DetailedName = "Type Incompatibility",
                        Link = "https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/casting-and-type-conversions",
                        CodeExample =
                        "public static void Main(String[] args)\n" +
                        "{\n" +
                        "\tint x = \"John\";  // Cannot implicitly convert type 'string' to 'int'\n" +
                        "}",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "Variables of different Types, such as \"string\" and \"int\", " +
                                      "are not able to be converted implicitly."
                    },

                    new Error
                    {
                        ErrorCategoryID = 1,
                        DetailedName = "System.IndexOutOfRangeException",
                        Link = "https://docs.microsoft.com/en-us/dotnet/api/system.indexoutofrangeexception?view=netframework-4.7.1",
                        CodeExample =
                        "int[] myarray = new int[10];\n" +
                        " myarray[5] = 5; \n" +
                        " myarray[10] = 10;\n" +
                        "Console.WriteLine(myarray);",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "Index was outside the bounds of the array."
                    },

                    new Error
                    {
                        ErrorCategoryID = 0,
                        DetailedName = "Loop doesn't Terminate",
                        Link = "https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/error-types",
                        CodeExample =
                        "string x = Console.ReadLine(); \n" +
                        "while (x != null)" +
                        "{\n" +
                        "Console.WriteLine(x);\n" +
                        "}",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "Constantly prints to console with loop that doesn't end."
                    },

                    new Error
                    {
                        ErrorCategoryID = 1,
                        DetailedName = "System.IO.FileNotFoundException",
                        Link = "https://docs.microsoft.com/en-us/dotnet/api/system.io.filenotfoundexception?view=netframework-4.7.1",
                        CodeExample =
                        "using (StreamReader sr = new StreamReader(path: \"../somthing.txt\"));",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "if file is not on in path throws file not found",
                    },

                    new Error
                    {
                        ErrorCategoryID = 2,
                        DetailedName = "Missing semicolon",
                        Link = "",
                        CodeExample =
                        "int a = 5   // semicolon is missing, ';' expected",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "Forgetting to put semicolon after statement",
                    });

                await context.SaveChangesAsync();
            }
        }
    }
}
