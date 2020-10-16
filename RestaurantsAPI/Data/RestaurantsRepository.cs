using Microsoft.EntityFrameworkCore;
using RestaurantsAPI.Interfaces;
using RestaurantsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantsAPI.Data
{
    public class RestaurantsRepository : IRestaurantsRepository
    {
        private WebApiContext context;
        private bool disposedValue;

        public RestaurantsRepository(WebApiContext webApiContext)
        {
            context = webApiContext;
        }

        public void Add(Restaurant entity)
        {
            context.Restaurants.Add(entity);
        }

        public void Delete(Restaurant entity)
        {
            context.Restaurants.Remove(entity);
        }

        public IQueryable<Restaurant> GetRestaurants()
        {
            return context.Restaurants.Include(x => x.City);
        }

        public Restaurant Get(int id)
        {
            return context.Restaurants.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Restaurant entity)
        {
            context.Restaurants.Update(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IQueryable<Restaurant> FindByCityName(string cityName)
        {
            return context.Restaurants
                .Where(x => x.City.Name.ToLower().Contains(cityName.ToLower()))
                .AsQueryable();
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
