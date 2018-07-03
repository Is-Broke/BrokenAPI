using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrokenApi.Models
{
    public class ErrorCategory
    {
        public int ID { get; set; }
        public ErrorType ErrorType { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
    }

    public enum ErrorType
    {
        Logic,
        Runtime,
        Syntax
    }
}
