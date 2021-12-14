using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataMergeEditor_Restfull_API.Models.EntityModels.Game
{
    public class GamesContextModel : DbContext
    {
        public GamesContextModel(DbContextOptions<GamesContextModel> options) :base(options)
        {

        }

       public DbSet<Games> Games { get; set; }
    }
}
