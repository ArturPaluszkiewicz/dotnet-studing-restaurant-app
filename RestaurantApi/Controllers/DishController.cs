using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Models;
using RestaurantApi.Services;

namespace RestaurantApi.Controller
{
    [Route("api/restaurant/{restaurantId}/dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _service;
        public DishController(IDishService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int restaurantId,[FromBody] CreateDishDto dto)
        {
            var newDishId = _service.CreateDish(restaurantId, dto);

            return Created($"api/restaurant/{restaurantId}/dish/{newDishId}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<DishDto>> GetAll([FromRoute] int restaurantId)
        {
            var dishesDto = _service.GetAllDishes(restaurantId);

            return Ok(dishesDto);
        }

        [HttpGet("{dishId}")]
        public ActionResult<DishDto> GetById([FromRoute]int restaurantId, [FromRoute]int dishId)
        {
            var dishDto = _service.GetDishById(restaurantId,dishId);

            return Ok(dishDto);
        }

        [HttpDelete]
        public ActionResult DeleteAll([FromRoute]int restaurantId)
        {
            _service.DeleteAllDishes(restaurantId);

            return NoContent();
        }

        [HttpDelete("{dishId}")]
        public ActionResult DeleteById([FromRoute]int restaurantId,[FromRoute]int dishId)
        {
            _service.DeleteDishById(restaurantId,dishId);

            return NoContent();
        }
    }
}