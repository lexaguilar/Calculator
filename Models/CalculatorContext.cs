using System.Collections.Generic;
using Calculator.Models;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Services
{

    public class CalculatorContext : DbContext
    {
        public DbSet<IR> IRS { get; set; }
        public DbSet<Inss> Inss { get; set; }

        public CalculatorContext()
        {

        }

        public CalculatorContext(DbContextOptions<CalculatorContext> options)
            : base(options)
        {
            var count = this.IRS.CountAsync().Result;
            if (count == 0)
            {

                this.Add(new IR { Id = 1, From = 0.01M, To = 100_000M, Base = 0, Percent = 0, Excess = 0 });
                this.Add(new IR { Id = 2, From = 100_000.01M, To = 200_000M, Base = 0, Percent = 0.15M, Excess = 100_000 });
                this.Add(new IR { Id = 3, From = 200_000.01M, To = 350_000M, Base = 15_000M, Percent = 0.2M, Excess = 200_000M });
                this.Add(new IR { Id = 4, From = 350_000.01M, To = 500_000M, Base = 45_000M, Percent = 0.25M, Excess = 350_000M });
                this.Add(new IR { Id = 5, From = 500_000.01M, To = null, Base = 82_500, Percent = 0.3M, Excess = 500_000M });

                this.SaveChanges();
            }

            count = this.Inss.CountAsync().Result;
            if (count == 0)
            {

                this.Inss.Add(new Inss { Id=1, Value = 6.25M });            

                this.SaveChanges();
            }
        }
    }

}