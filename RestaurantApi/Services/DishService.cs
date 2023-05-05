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
            var restaurant = checkIfRestaurantExist(resId);

            var dish = _mapper.Map<Dish>(dto);

            dish.RestaurantId = resId;

            _dbContext.Dishes.Add(dish);
            _dbContext.SaveChanges();

            return dish.Id;
        }

        public void DeleteDishById(int resId, int dishId)
        {
            var restaurant = checkIfRestaurantExist(resId);

            var dish = restaurant.Dishes.Where(d => d.Id == dishId).FirstOrDefault();

            if (dish is null) throw new NotFoundException("Dish not found");

            _dbContext.Remove(dish);
            _dbContext.SaveChanges();
        }
        public void DeleteAllDishes(int resId)
        {
            var restaurant = checkIfRestaurantExist(resId);

            _dbContext.Dishes.RemoveRange(restaurant.Dishes);
            _dbContext.SaveChanges();
        }

        public IEnumerable<DishDto> GetAllDishes(int resId)
        {
            var restaurant = checkIfRestaurantExist(resId);

            var dishesDto = _mapper.Map<List<DishDto>>(restaurant.Dishes);

            return dishesDto;
        }

        public DishDto GetDishById(int resId, int dishId)
        {
            var restaurant = checkIfRestaurantExist(resId);

            var dish = restaurant.Dishes.Where(d => d.Id == dishId).FirstOrDefault();

            if (dish is null) throw new NotFoundException("Dish not found");

            var dishDto = _mapper.Map<DishDto>(dish);
            return dishDto;
        }

        private Restaurant checkIfRestaurantExist(int resId)
        {
            var restaurant = _dbContext.Restaurants.Include(r => r.Dishes).FirstOrDefault(r => r.Id == resId);

            if (restaurant is null) throw new NotFoundException("Restaurant not Found");

            return restaurant;
        }
    }
}