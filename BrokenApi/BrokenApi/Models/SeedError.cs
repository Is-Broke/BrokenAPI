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
                        Description = "Code executes but does not produce is not the expected output."
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
                         Description = "Code executes but does not produce is not the expected output."
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
                        "\tint quotient = 5 / 0;\n" +
                        "\tConsole.WriteLine(quotient)\n" +
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
                        DetailedName = "IndexOutOfRange Exception",
                        Link = "https://docs.microsoft.com/en-us/dotnet/api/system.indexoutofrangeexception?view=netframework-4.7.1",
                        CodeExample =
                        "public static void Main(String[] args)\n" +
                        "{\n" +
                        "\tint[] myarray = new int[5];\n" +
                        "\tmyarray[10] = 10;\n" +
                        "}",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "Error caused when trying to access an index outside of the range " +
                                      "specified by the size of an array."
                    },

                    new Error
                    {
                        ErrorCategoryID = 0,
                        DetailedName = "Infinite Loop",
                        CodeExample =
                        "public static void Main(String[] args)\n" +
                        "{\n" +
                        "\tint x = 1; \n" +
                        "\twhile (x == 1)\n" +
                        "\t{\n" +
                        "\t\tConsole.WriteLine(x);\n" +
                        "\t}\n" +
                        "}",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "Inifite loops are caused when a condition is never mutated, in order " +
                                      "to return \"false\" and exit the loop. This will cause the loop to run " +
                                      "continuously, typically causes the system to freeze as a result."
                    },

                    new Error
                    {
                        ErrorCategoryID = 1,
                        DetailedName = "FileNotFound Exception",
                        Link = "https://docs.microsoft.com/en-us/dotnet/api/system.io.filenotfoundexception?view=netframework-4.7.1",
                        CodeExample =
                        "public static void Main(String[] args)\n" +
                        "{\n" +
                        "\tusing (StreamReader sr = new StreamReader(path: \"../example.txt\"));\n" +
                        "}",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "This error is caused when attempting to access a file that " +
                                      "does not exist at the specified path.",
                    },

                    new Error
                    {
                        ErrorCategoryID = 2,
                        DetailedName = "Missing Semicolon",
                        CodeExample =
                        "public static void Main(String[] args)\n" +
                        "{\n" +
                        "\t int a = 5   // semicolon is missing, ';' expected\n" +
                        "}",
                        IsUserExample = false,
                        Votes = 0,
                        Rating = 0,
                        Description = "Common syntax error which occurs when a semicolon is not added " +
                                      "at the end of a statement.",
                    });

                await context.SaveChangesAsync();
            }
        }
    }
}
