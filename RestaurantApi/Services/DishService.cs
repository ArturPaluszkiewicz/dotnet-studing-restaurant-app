using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public void DeleteDish(int resId, int dishId)
        {
            var restaurant = _dbContext.Restaurants.FirstOrDefault(r => r.Id == resId);

            if (restaurant is null) throw new NotFoundException("Restaurant not Found");

            throw new NotImplementedException();
        }

        public IEnumerable<DishDto> GetAllDishes(int resId)
        {
            var restaurant = _dbContext.Restaurants.Include(r => r.Dishes).FirstOrDefault(r => r.Id == resId);

            if (restaurant is null) throw new NotFoundException("Restaurant not Found");

            var dishesDto = _mapper.Map<List<DishDto>>(restaurant.Dishes);

            return dishesDto;
        }

        public DishDto GetDish(int resId, int dishId)
        {
            var restaurant = _dbContext.Restaurants.Include(r => r.Dishes).FirstOrDefault(r => r.Id == resId);

            if (restaurant is null) throw new NotFoundException("Restaurant not Found");

            var dish = restaurant.Dishes.Where(d => d.Id == dishId).FirstOrDefault();

            if (dish is null) throw new NotFoundException("Dish not found");

            var dishDto = _mapper.Map<DishDto>(dish);
            return dishDto;
        }
    }
}