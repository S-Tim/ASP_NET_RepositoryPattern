using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ASP_Net_RepositoryPattern.Models;

namespace ASP_Net_RepositoryPattern.DAL
{
    public class SeriesReminderContext : DbContext
    {
        public SeriesReminderContext() : base(nameof(SeriesReminderContext))
        {   
        }

        public DbSet<Series> Series { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}