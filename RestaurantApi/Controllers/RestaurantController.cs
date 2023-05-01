using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Entities;

namespace RestaurantApi.Controller
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantController(RestaurantDbContext dbContext){
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> getAll()
        {
            var restaurants = _dbContext.Restaurants.ToList();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public ActionResult<Restaurant> getById([FromRoute]int id)
        {
            var restaurant = _dbContext.Restaurants.FirstOrDefault(r => r.Id == id);

            if (restaurant is null)
            {
                return NotFound("Nie znaleziono");
            }

            return Ok(restaurant);
        }
    }
}