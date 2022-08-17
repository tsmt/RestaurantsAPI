using Microsoft.EntityFrameworkCore;
using RestaurantsAPI.Interfaces;
using RestaurantsAPI.Models;

namespace RestaurantsAPI.Data
{
    public class CitiesRepository : ICitiesRepository
    {
        private WebApiContext context;
        private bool disposedValue;

        public CitiesRepository(WebApiContext webApiContext)
        {
            context = webApiContext;
        }

        public void Add(City entity)
        {
            if (!String.IsNullOrEmpty(entity.Name))
            {
                if (!context.Cities.Any(x => x.Name.ToLower() == entity.Name.ToLower()))
                {
                    context.Add(entity);
                }
            }
        }

        public void Delete(City entity)
        {
            context.Remove(entity);
        }

        public City Get(int id)
        {
            return context.Cities.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<City> GetCities()
        {
            return context.Cities.Include(x => x.Restaurants);
        }

        public void Update(City entity)
        {
            context.Update(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
