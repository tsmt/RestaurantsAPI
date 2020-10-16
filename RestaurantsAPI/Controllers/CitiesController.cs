using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantsAPI.Interfaces;
using RestaurantsAPI.Models;

namespace RestaurantsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        ICitiesRepository rep;

        public CitiesController(ICitiesRepository repository)
        {
            rep = repository;
        }

        /// <summary>
        /// Возвращает список городов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> Get()
        {
            return await rep.GetCities().ToListAsync();
        }

        /// <summary>
        /// Добавляет город
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateCity(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                rep.Add(new City() { Name = cityName });
                await Task.Run(() => rep.Save());
                return Created("restaurants", cityName);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
