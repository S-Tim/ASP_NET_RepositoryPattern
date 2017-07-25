using ASP_Net_RepositoryPattern.DAL.Interfaces;
using ASP_Net_RepositoryPattern.Models;
using ASP_Net_RepositoryPatternTest.Mocks.RepositoryMocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASP_Net_RepositoryPatternTest
{
    // TODO actually this should test a SeriesService that has an ISeriesRepository but I have not implemented the service yet. This is testing the MockRepository
    [TestClass]
    public class SeriesServiceTest
    {
        private readonly ISeriesRepository _seriesRepository = new MockSeriesRepository();

        [TestMethod]
        public void TestAddSeriesAndGetById()
        {
            Series series = new Series { Title = "Game of Thrones", Episode = 1, Season = 2, Id = 123 };

            _seriesRepository.Insert(series);
            var retrieved = _seriesRepository.GetById(123);

            Assert.AreEqual(series.Id, retrieved.Id);
            Assert.AreEqual(series.Title, retrieved.Title);
            Assert.AreEqual(series.Episode, retrieved.Episode);
            Assert.AreEqual(series.Season, retrieved.Season);
        }
    }
}
