using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApi.Entities;
using RestaurantApi.Models;
using RestaurantApi.Services;

namespace RestaurantApi.Controller
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _service;

        public RestaurantController(IRestaurantService service){
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> getAll()
        {
            var restaurantsDto = _service.GetAllRestaurants();
            return Ok(restaurantsDto);
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> getById([FromRoute]int id)
        {
            var restaurantDto = _service.GetById(id);
            if (restaurantDto is null)
            {
                return NotFound("Nie znaleziono");
            }
            return Ok(restaurantDto);
        }

        [HttpPost]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _service.AddRestuarant(dto);
            return Created($"/api/restaurant/{id}",null);
        }
    }
}