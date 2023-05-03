using RestaurantApi.Models;

namespace RestaurantApi.Services
{
    public interface IRestaurantService
    {
        public IEnumerable<RestaurantDto> GetAllRestaurants();
        public RestaurantDto GetById(int id);
        public int AddRestuarant(CreateRestaurantDto dto);

        public bool DeleteRestaurant(int id);
        
    }
}