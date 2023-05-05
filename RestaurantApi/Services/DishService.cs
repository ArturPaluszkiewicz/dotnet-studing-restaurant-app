using AutoMapper;
using RestaurantApi.Entities;
using RestaurantApi.Exceptions;
using RestaurantApi.Models;

namespace RestaurantApi.Services
{
    public class DishService : IDishService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;
        public DishService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int CreateDish(int resId, CreateDishDto dto)
        {
            var restaurant = _dbContext.Restaurants.FirstOrDefault(r => r.Id == resId);

            if (restaurant is null) throw new NotFoundException("Restaurant not Found");

            var dish = _mapper.Map<Dish>(dto);

            dish.RestaurantId = resId;

            _dbContext.Dishes.Add(dish);
            _dbContext.SaveChanges();

            return dish.Id;
        }
    }
}