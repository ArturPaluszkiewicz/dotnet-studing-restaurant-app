using RestaurantApi.Models;

namespace RestaurantApi.Services
{
    public interface IDishService
    {
        public int CreateDish(int resId, CreateDishDto dto);
    }
}