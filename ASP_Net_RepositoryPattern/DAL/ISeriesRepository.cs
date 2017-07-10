﻿using ASP_Net_RepositoryPattern.Models;

namespace ASP_Net_RepositoryPattern.DAL
{
    public interface ISeriesRepository : IRepository<Series>
    {
        Series GetSeriesByTitle(string title);
    }
}
