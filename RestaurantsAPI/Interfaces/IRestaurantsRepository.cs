using RestaurantsAPI.Models;

namespace RestaurantsAPI.Interfaces
{
    public interface IRestaurantsRepository : IData<Restaurant>, IDisposable
    {
        IQueryable<Restaurant> GetRestaurants();
        IQueryable<Restaurant> FindByCityName(string city);
    }
}
