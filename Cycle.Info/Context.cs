using Cycle.Info.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycle.Info
{
    public class Context : DbContext
    {
        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<User> Users { get; set; }

        public Context() : base("CycleDatabase")
        {

        }
    }
}
