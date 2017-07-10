using System.Collections.Generic;
using System.Data.Entity;
using ASP_Net_RepositoryPattern.Models;

namespace ASP_Net_RepositoryPattern.DAL
{
    public class SeriesReminderInitializer : DropCreateDatabaseIfModelChanges<SeriesReminderContext>
    {
        protected override void Seed(SeriesReminderContext context)
        {
            var series = new List<Series>
            {
                new Series {Title = "Game of Thrones", Season = 1, Episode = 1},
                new Series {Title = "Fargo", Season = 1, Episode = 1},
                new Series {Title = "Suits", Season = 1, Episode = 1}
            };

            series.ForEach(s => context.Series.Add(s));
            context.SaveChanges();
        }
    }
}