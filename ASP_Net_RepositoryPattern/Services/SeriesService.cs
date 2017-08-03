using System;
using System.Collections.Generic;
using ASP_Net_RepositoryPattern.DAL.Interfaces;
using ASP_Net_RepositoryPattern.Models;

namespace ASP_Net_RepositoryPattern.Services
{
    public class SeriesService
    {
        private readonly ISeriesRepository _seriesRepository;

        public SeriesService(ISeriesRepository seriesRepository)
        {
            _seriesRepository = seriesRepository;
        }

        public IEnumerable<Series> GetAllSeries()
        {
            return _seriesRepository.Get();
        }

        public Series GetSeries(int id)
        {
            var series = _seriesRepository.GetById(id);

            // We don't want to return null
            if (series == null)
            {
                // TODO Maybe change this to a NotFound exception
                throw new ArgumentException("Series with the given Id does not exist", nameof(id));
            }

            return series;
        }

        public void InsertSeries(Series series)
        {
            _seriesRepository.Insert(series);
            _seriesRepository.Save();
        }

        public void UpdateSeries(Series series)
        {
            _seriesRepository.Update(series);
            _seriesRepository.Save();
        }

        public void DeleteSeries(int id)
        {
            _seriesRepository.Delete(id);
            _seriesRepository.Save();
        }
    }
}