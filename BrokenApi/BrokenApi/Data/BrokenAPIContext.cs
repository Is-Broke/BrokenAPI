using BrokenApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrokenApi.Data
{
    public class BrokenAPIContext : DbContext
    {
        public BrokenAPIContext(DbContextOptions<BrokenAPIContext> options) : base(options) { }
        
        public DbSet<ErrorCategory> Categories { get; set; }
        public DbSet<Error> Errors { get; set; }
    }
}
