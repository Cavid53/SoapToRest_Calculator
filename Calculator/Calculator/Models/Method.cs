using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class Method
    {
        public Method()
        {
            this.INSERT_DATE = DateTime.Now;
        }
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
