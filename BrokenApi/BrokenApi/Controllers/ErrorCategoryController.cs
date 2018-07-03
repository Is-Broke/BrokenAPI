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

        }

        //[HttpGet]
        //public async Task<ActionResult<Error>> GetAllCategories()
        //{
        //    if (_context.Categories == null)
        //    {

        //    }
        //}
    }
}