using System.Linq;
using ASP_Net_RepositoryPattern.Models;

namespace ASP_Net_RepositoryPattern.DAL.Implementations
{
    public class MockSeriesRepository : GenericMockRepository<Series>
    {
        public override Series GetById(object id)
        {
            return EntitySet.FirstOrDefault(series => series.Id == (int) id);
        }
    }
}