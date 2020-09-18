using DangerTapeAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DangerTapeAPI.Database.Context
{
    public class DangerTapeDBContext : DbContext
    {
        public DangerTapeDBContext(DbContextOptions<DangerTapeDBContext> options)
            : base(options)
        {
        }

        public DbSet<Mode> Modes { get; set; }
    }
}