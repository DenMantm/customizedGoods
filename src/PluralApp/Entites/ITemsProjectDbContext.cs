using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralApp.Entites
{
    public class ITemsProjectDbContext :DbContext
    {
        public ITemsProjectDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ItemModel> ItemModels { get; set; }
        public DbSet<CountersModel> ItemCounters { get; set; }
    }
}
