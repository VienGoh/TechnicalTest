using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.Model;

namespace TechnicalTest.Data
{
    public class TechnicalTestContext : DbContext
    {
        public TechnicalTestContext (DbContextOptions<TechnicalTestContext> options)
            : base(options)
        {
        }

        public DbSet<TechnicalTest.Model.SalesOrder> SalesOrder { get; set; } = default!;
    }
}
