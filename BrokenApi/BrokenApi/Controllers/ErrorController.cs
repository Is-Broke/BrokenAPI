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

        // GET api/Error/Top
        // Returns most upvoted Error
        [HttpGet]
        [Route("/api/error")]
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
        
        // GET api/Error/All
        // Returns all Errors
        [HttpGet]
        [Route("/api/error/all")]
        public ActionResult<List<Error>> GetAll()
        {
            try
            {
                return _context.Errors.ToList();
            }
            catch
            {
                return NotFound();
            }
        }
        
        // GET api/Error/Search
        // GET api/Error/Search/{error name}
        [HttpGet]
        [Route("/api/error/search/{searchName?}")]
        public async Task<ActionResult<Error>> GetError(string searchName)
        {
            if (String.IsNullOrEmpty(searchName))
            {
                return BadRequest();
            }

            try
            {
                var foundError = await _context.Errors.FirstOrDefaultAsync(err => err.DetailedName == searchName);

                if (foundError != null)
                {
                    return foundError;
                }

                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }



    }
}