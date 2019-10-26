using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class Report
    {
        public Report()
        {
            this.INSERT_DATE = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public string VALUE { get; set; }
        public int MethodId { get; set; }
        public Method Method { get; set; }
    }
}
