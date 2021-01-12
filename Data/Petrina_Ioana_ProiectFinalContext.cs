using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Petrina_Ioana_ProiectFinal.Models;

namespace Petrina_Ioana_ProiectFinal.Data
{
    public class Petrina_Ioana_ProiectFinalContext : DbContext
    {
        public Petrina_Ioana_ProiectFinalContext (DbContextOptions<Petrina_Ioana_ProiectFinalContext> options)
            : base(options)
        {
        }

        public DbSet<Petrina_Ioana_ProiectFinal.Models.Coffee> Coffee { get; set; }
    }
}
