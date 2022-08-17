using Microsoft.AspNetCore.Mvc;
using RestaurantsAPI.Extensions;
using RestaurantsAPI.Interfaces;
using RestaurantsAPI.Models;

namespace RestaurantsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        IRestaurantsRepository rep;

        public RestaurantsController(IRestaurantsRepository restaurantsRepository)
        {
            rep = restaurantsRepository;
        }

        /// <summary>
        /// Возвращает список ресторанов
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetByCity([FromQuery] RestaurantParameters parameters)
        {
            return await PagedList<Restaurant>.ToPagedListAsync(
                rep.FindByCityName(parameters.CityName ?? string.Empty), 
                parameters.PageNumber, parameters.PageSize);
        }

        /// <summary>
        /// Добавляет ресторан
        /// </summary>
        /// <param name="restaurantName">Наименование ресторана</param>
        /// <param name="cityId">Идентификатор города</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateRestaurant(string restaurantName, int cityId)
        {
            if (!string.IsNullOrEmpty(restaurantName))
            {
                rep.Add(new Restaurant() { CityId = cityId, Name = restaurantName });
                await Task.Run(() => rep.Save());
                return Created("restaurants", restaurantName);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
