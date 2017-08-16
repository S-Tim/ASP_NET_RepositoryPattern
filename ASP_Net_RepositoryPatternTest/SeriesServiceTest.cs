using ASP_Net_RepositoryPattern.Models;
using ASP_Net_RepositoryPattern.Services;
using ASP_Net_RepositoryPatternTest.Mocks.RepositoryMocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASP_Net_RepositoryPatternTest
{
    [TestClass]
    public class SeriesServiceTest
    {
        private readonly SeriesService _seriesService = new SeriesService(new MockSeriesRepository());

        [TestMethod]
        public void TestAddSeriesAndGetById()
        {
            Series series = new Series { Title = "Game of Thrones", Episode = 1, Season = 2, Id = 123 };

            _seriesService.InsertSeries(series);

            var retrieved = _seriesService.GetSeries(123);

            Assert.AreEqual(series.Id, retrieved.Id);
            Assert.AreEqual(series.Title, retrieved.Title);
            Assert.AreEqual(series.Episode, retrieved.Episode);
            Assert.AreEqual(series.Season, retrieved.Season);
        }
    }
}
