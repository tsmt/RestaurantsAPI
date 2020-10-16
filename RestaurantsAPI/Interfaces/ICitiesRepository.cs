using System;
using System.Linq;
using RestaurantsAPI.Models;

namespace RestaurantsAPI.Interfaces
{
    public interface ICitiesRepository : IData<City>, IDisposable
    {
        IQueryable<City> GetCities();
    }
}
