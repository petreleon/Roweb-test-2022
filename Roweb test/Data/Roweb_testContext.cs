using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Roweb_test.Models;

namespace Roweb_test.Data
{
    public class Roweb_testContext : DbContext
    {
        public Roweb_testContext (DbContextOptions<Roweb_testContext> options)
            : base(options)
        {
        }

        public DbSet<Roweb_test.Models.Movie>? Movie { get; set; }

        public DbSet<Roweb_test.Models.Game>? Game { get; set; }
    }
}
