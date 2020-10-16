using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantsAPI.Models;

namespace RestaurantsAPI.Interfaces
{
    public interface IRestaurantsRepository : IData<Restaurant>, IDisposable
    {
        IQueryable<Restaurant> GetRestaurants();
        IQueryable<Restaurant> FindByCityName(string city);
    }
}
