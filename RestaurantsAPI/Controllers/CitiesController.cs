using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantsAPI.Data;
using RestaurantsAPI.Interfaces;
using RestaurantsAPI.Models;

namespace RestaurantsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        CitiesRepository rep;

        public CitiesController(ICitiesRepository repository)
        {
            rep = (CitiesRepository) repository;
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
                return Created("City", cityName);
            }
            else
            {
                return BadRequest("Не удалось создать город");
            }
        }
    }
}
