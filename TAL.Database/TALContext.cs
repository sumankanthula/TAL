using System;
using System.Data.Entity;
using TAL.Database;

namespace TALDbContext
{
    public class TALContext : DbContext
    {
        public TALContext() : base()
        {

        }

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<OccupationRating> OccupationRatings { get; set; }
    }
}
