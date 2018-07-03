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
                        ErrorType = "Logic",
                        Description = "Logic errors are those that appear once the application is in use. They are most often unwanted or unexpected results in response to user actions. For example, a mistyped key or other outside influence might cause your application to stop working within expected parameters, or altogether. Logic errors are generally the hardest type to fix, since it is not always clear where they originate.",
                    },
                    new ErrorCategory
                    {
                        ErrorType = "Runtime",
                        Description = "Run-time errors are those that appear only after you compile and run your code. These involve code that may appear to be correct in that it has no syntax errors, but that will not execute. For example, you might correctly write a line of code to open a file. But if the file is corrupted, the application cannot carry out the Open function, and it stops running. You can fix most run-time errors by rewriting the faulty code, and then recompiling and rerunning it",
                    },
                    new ErrorCategory
                    {
                        ErrorType = "Syntax",
                        Description = "Syntax errors are those that appear while you write code. Visual Basic checks your code as you type it in the Code Editor window and alerts you if you make a mistake, such as misspelling a word or using a language element improperly. Syntax errors are the most common type of errors. You can fix them easily in the coding environment as soon as they occur.",
                    });

                await context.SaveChangesAsync();
            }
        }
    }
}
