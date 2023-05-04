using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantApi.Entities;
using RestaurantApi.Models;

namespace RestaurantApi.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RestaurantService> _logger;
        public RestaurantService(RestaurantDbContext dbContext, IMapper mapper, ILogger<RestaurantService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public int AddRestuarant(CreateRestaurantDto dto)
        {
            var restaurant = _mapper.Map<Restaurant>(dto);
            _dbContext.Add(restaurant);
            _dbContext.SaveChanges();
            return restaurant.Id;
        }

        public bool DeleteRestaurant(int id)
        {
            _logger.LogWarning($"Restaurant with id: {id} DELETE action invoke");

            var restaurant = _dbContext
                .Restaurants
                .FirstOrDefault(r => r.Id == id);

            if (restaurant is null) return false;

            _dbContext.Remove(restaurant);
            _dbContext.SaveChanges();
            return true;
        }

        public bool ChangeRestaurant(int id, PutRestaurantDto dto)
        {
            var restaurant = _dbContext
                .Restaurants
                .FirstOrDefault(r => r.Id == id);
            
            if (restaurant is null) return false;

            restaurant.Name = dto.Name;
            restaurant.Description = dto.Description;
            restaurant.HasDelivery = dto.HasDelivery;

            _dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<RestaurantDto> GetAllRestaurants()
        {
            var restaurants = _dbContext
                .Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .ToList();

            if (restaurants is null) return null;

            return _mapper.Map<List<RestaurantDto>>(restaurants);
        }

        public RestaurantDto GetById(int id)
        {
            var restaurant = _dbContext
                .Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .FirstOrDefault(r => r.Id == id);

            if (restaurant is null) return null;

            return _mapper.Map<RestaurantDto>(restaurant);
        }
    }
}