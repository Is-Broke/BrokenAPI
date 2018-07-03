using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrokenApi.Models
{
    public class ErrorCategory
    {
        public int ID { get; set; }
        public string ErrorType { get; set; }
        public string Description { get; set; }
    }
}
