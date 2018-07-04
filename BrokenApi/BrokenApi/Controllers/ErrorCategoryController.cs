using System;
using System.Collections;
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

        /// <summary>
        /// gets all Error Types and discriptions.
        /// </summary>
        /// <returns>all type name and discriptions</returns>
        [HttpGet]
        public async Task<List<ErrorCategory>> GetAllCategories()
        {

            var getCategories = await (from all in _context.Categories
                                       select all).ToListAsync();

            return getCategories;

        }

        /// <summary>
        /// If user wants to see a single type with discription
        /// </summary>
        /// <param name="errortype">Name of Type(Logic or RunTime or Syntax)</param>
        /// <returns>one type with discription</returns>
        [HttpGet("{errorType}")]//api/errorCategory/(errorType)
        public async Task<ActionResult<ErrorCategory>> GetOneCategory(string errortype)
        {

            var getOneFromCategory = await (from oneCategory in _context.Categories
                                            where oneCategory.ErrorType.ToString() == errortype
                                            select oneCategory).FirstOrDefaultAsync();

            return getOneFromCategory;
        }

        /// <summary>
        /// If user wants to see specific Type definition and error examples of that type
        /// user can request with api/errorCategory/(the Type)/list
        /// will return array with Type and Definition at index 0 and error examples at other indexies.
        /// </summary>
        /// <param name="errortype">the type of error and / list</param>
        /// <returns>type with discription and error examples of that type in an array</returns>
        [HttpGet("{errorType}/list")]//api/errorCategory/(type)/list
        public async Task<ArrayList> GetAllTypeError(string errortype)
        {
            string listofTypeName = errortype.ToLower();

            ArrayList list = new ArrayList();
            
            var getOneFromCategory = await (from oneCategory in _context.Categories
                                            where oneCategory.ErrorType.ToString() == errortype
                                            select oneCategory).FirstOrDefaultAsync();
            switch (listofTypeName)
            {
                case "logic":
                    var getLogicExamples = await (from allErrorExamp in _context.Errors
                                                  where allErrorExamp.ErrorCategoryID == 0
                                                  select allErrorExamp).ToListAsync();
                    list.Add(getOneFromCategory);
                    list.Add(getLogicExamples);
                    return list;
                case "runtime":
                    var getRuntimeExamples = await (from allErrorExamp in _context.Errors
                                                  where allErrorExamp.ErrorCategoryID == 1
                                                  select allErrorExamp).ToListAsync();
                    list.Add(getOneFromCategory);
                    list.Add(getRuntimeExamples);
                    return list;
                case "syntax":
                    var getSyntaxExamples = await (from allErrorExamp in _context.Errors
                                                    where allErrorExamp.ErrorCategoryID == 2
                                                    select allErrorExamp).ToListAsync();
                    list.Add(getOneFromCategory);
                    list.Add(getSyntaxExamples);
                    return list;
                default:
                    list.Add(getOneFromCategory);
                    return list;
            }
 
        }

        /// <summary>
        /// if user wants to see all types with discription and error examples
        /// </summary>
        /// <returns>and array of Types w/ description and error examples</returns>
        [HttpGet("listAll")]//api/ErrorCategory/listAll
        public async Task<ArrayList> GetAllTypesAndError()
        {
            ArrayList list = new ArrayList();

            var getCategories = await (from all in _context.Categories
                                       select all).ToListAsync();

            var getLogicExamples = await (from allErrorExamp in _context.Errors
                                          where allErrorExamp.ErrorCategoryID == 0
                                          select allErrorExamp).ToListAsync();
            list.Add(getCategories[0]);
            list.Add(getLogicExamples);

            var getRuntimeExamples = await (from allErrorExamp in _context.Errors
                                            where allErrorExamp.ErrorCategoryID == 1
                                            select allErrorExamp).ToListAsync();
            list.Add(getCategories[1]);
            list.Add(getRuntimeExamples);

            var getSyntaxExamples = await (from allErrorExamp in _context.Errors
                                           where allErrorExamp.ErrorCategoryID == 2
                                           select allErrorExamp).ToListAsync();
            list.Add(getCategories[2]);
            list.Add(getSyntaxExamples);
            return list;
        }
    }
}
