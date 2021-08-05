using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pcoint.Models;

namespace Pcoint.Data
{
    public class PcointContext : DbContext
    {
        public PcointContext (DbContextOptions<PcointContext> options)
            : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<YourProducts> YourProducts { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Authenticate> Authenticate { get; set; }
    }
}
