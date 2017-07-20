using System.Linq;
using ASP_Net_RepositoryPattern.Models;

namespace ASP_Net_RepositoryPattern.DAL
{
    public class SeriesRepository : GenericRepository<SeriesReminderContext, Series>, ISeriesRepository
    {
        public SeriesRepository(SeriesReminderContext context) : base(context)
        {
        }

        public Series GetSeriesByTitle(string title)
        {
            return Get(series => series.Title == title).FirstOrDefault();
        }
    }
}