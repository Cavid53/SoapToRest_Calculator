using Calculator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.DAL
{
    public class CalculatorDbContext:DbContext
    {
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options):base(options)
        {

        }
        public DbSet<Method> Methods { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
