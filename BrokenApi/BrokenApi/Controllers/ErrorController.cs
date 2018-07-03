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
    [Route("api/Error")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private BrokenAPIContext _context;

        public ErrorController(BrokenAPIContext context)
        {
            _context = context;
        }

        // GET api/Error
        // Returns most upvoted Error
        [HttpGet]
        public async Task<ActionResult<Error>> GetTop()
        {
            if (_context.Errors == null)
            {
                return NotFound();
            }

            var topError = _context.Errors.OrderByDescending(err => err.Votes)
                                   .FirstOrDefaultAsync();

            return await topError;
        }



    }
}