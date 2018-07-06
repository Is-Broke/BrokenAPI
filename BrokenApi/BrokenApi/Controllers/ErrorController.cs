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
        /// <summary>
        /// Sets up context field for connecting to database
        /// </summary>
        private BrokenAPIContext _context;

        /// <summary>
        /// Constructor method for the Controller
        /// </summary>
        /// <param name="context">connection to database</param>
        public ErrorController(BrokenAPIContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Asynchronous method which returns the Error with the most upvotes from the database.
        /// Route: api/Error/
        /// </summary>
        /// <returns>Error object</returns>
        [HttpGet]
        [Route("/api/error")]
        public async Task<ActionResult<Error>> GetTop()
        {
            var topError = _context.Errors.OrderByDescending(err => err.Votes)
                                          .FirstOrDefaultAsync();

            return await topError;
        }
        
        /// <summary>
        /// Asynchronous method which returns all Errors from the database.
        /// Route: api/Error/All
        /// </summary>
        /// <returns>List of Error objects</returns>
        [HttpGet]
        [Route("/api/error/all")]
        public async Task<ActionResult<List<Error>>> GetAll()
        {
            return await _context.Errors.ToListAsync();
        }

        /// <summary>
        /// Asynchronous method which returns the Error which has the same DetailedName as the searched name.
        /// Route: api/Error/Search/{search name}
        /// </summary>
        /// <param name="searchName">Error name to search the database for</param>
        /// <returns>Error object</returns>
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

        /// <summary>
        /// Asynchronous method which adds an Error the the database.
        /// Route: api/Error/Create
        /// </summary>
        /// <param name="newError">Error to add to the database</param>
        /// <returns>CreatedResult object</returns>
        [HttpPost]
        [Route("/api/error/create")]
        public async Task<IActionResult> PostError(Error newError)
        {
            if (newError.DetailedName == null)
            {
                throw new ArgumentNullException();
            }

            var foundError = await _context.Errors.FirstOrDefaultAsync(err => err.DetailedName == newError.DetailedName);

            if (foundError != null)
            {
                return Conflict();
            }
            
            try
            {
                await _context.Errors.AddAsync(newError);
                await _context.SaveChangesAsync();
                
                return Created($"/api/error/search/{newError.DetailedName}", newError);
            }
            catch
            {
                return BadRequest();
            }
        }
        
        /// <summary>
        /// Asynchronous method which increments the Vote property on an Error object.
        /// Route: api/Error/{error id}
        /// </summary>
        /// <param name="id">ID of the Error to increment Vote for</param>
        /// <returns>OkResult object</returns>
        [HttpPut]
        [Route("/api/error/{id}")]
        public async Task<IActionResult> AddVote(int id)
        {
            var foundError = await _context.Errors.FirstOrDefaultAsync(err => err.ID == id);

            if (foundError == null)
            {
                return NotFound();
            }

            try
            {
                foundError.Votes++;
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        
        /// <summary>
        /// Asynchronous method which removes an Error from the database.
        /// Route: api/Error/{error id}
        /// </summary>
        /// <param name="id">ID of the Error to remove from the database</param>
        /// <returns>OkResult object</returns>
        [HttpDelete]
        [Route("/api/error/{id}")]
        public async Task<IActionResult> DeleteError(int id)
        {
            var foundError = await _context.Errors.FirstOrDefaultAsync(err => err.ID == id);

            if (foundError == null)
            {
                return NotFound();
            }

            try
            {
                _context.Errors.Remove(foundError);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}