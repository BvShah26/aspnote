using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace MultiplexApis.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Screens> Screens { get; set; }
        public DbSet<Multiplex> Multiplex { get; set; }
        public DbSet<MultiMovie> MultiMovie { get; set; }
    }
}
