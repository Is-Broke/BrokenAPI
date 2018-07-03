using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrokenApi.Models
{
    public class Error
    {
        public int ID { get; set; }
        public int ErrorCategoryID { get; set; }
        public string CodeExample { get; set; }
        public string DetailedName { get; set; }
        public int Votes { get; set; }
        public int Rating { get; set; }
    }
}
