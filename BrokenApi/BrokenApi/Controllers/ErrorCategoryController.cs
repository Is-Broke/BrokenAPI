using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrokenApi.Data;
using BrokenApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrokenApi.Controllers
{
    [Route("api/ErrorCategory")]
    [ApiController]
    public class ErrorCategoryController : ControllerBase
    {
        private BrokenAPIContext _context;

        public ErrorCategoryController(BrokenAPIContext context)
        {
            _context = context;

            if (_context.Categories.Count() == 0)
            {
                _context.Categories.Add(new ErrorCategory { Name = "Test Error Category" });
                _context.SaveChanges();
            }
        }
    }
}