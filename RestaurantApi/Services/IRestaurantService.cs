using RestaurantApi.Models;

namespace RestaurantApi.Services
{
    public interface IRestaurantService
    {
        public IEnumerable<RestaurantDto> GetAllRestaurants();
        public RestaurantDto GetById(int id);
        public int AddRestuarant(CreateRestaurantDto dto);
        public void DeleteRestaurant(int id);
        public void ChangeRestaurant(int id, PutRestaurantDto dto);
        
    }
}