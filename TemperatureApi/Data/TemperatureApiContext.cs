using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TemperatureApi.Models
{
    public class TemperatureApiContext : DbContext
    {
        public TemperatureApiContext (DbContextOptions<TemperatureApiContext> options)
            : base(options)
        {
        }

        public DbSet<TemperatureApi.Models.TemperatureEntry> TemperatureEntry { get; set; }
    }
}
