using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrokenApi.Data;
using BrokenApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public async Task<List<ErrorCategory>> GetAllCategories()
        {

            var getCategories = await (from all in _context.Categories
                                       select all).ToListAsync();

            return getCategories;

        }


        [HttpGet("{ErrorType}")]//api/errorCategory/ErrorType
        public async Task<ActionResult<ErrorCategory>> GetOneCategory(string errortype)
        {

            var getOneFromCategory = await (from oneCategory in _context.Categories
                                            where oneCategory.ErrorType.ToString() == errortype
                                            select oneCategory).FirstOrDefaultAsync();

            return getOneFromCategory;
        }
    }
}
