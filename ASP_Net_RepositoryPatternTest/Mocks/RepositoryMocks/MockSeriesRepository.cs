using System.Linq;
using ASP_Net_RepositoryPattern.DAL.Interfaces;
using ASP_Net_RepositoryPattern.Models;

namespace ASP_Net_RepositoryPatternTest.Mocks.RepositoryMocks
{
    public class MockSeriesRepository : GenericMockRepository<Series>, ISeriesRepository
    {
        public override Series GetById(object id)
        {
            return EntitySet.FirstOrDefault(series => series.Id == (int)id);
        }

        public Series GetSeriesByTitle(string title)
        {
            return Get(series => series.Title == title).FirstOrDefault();
        }
    }
}