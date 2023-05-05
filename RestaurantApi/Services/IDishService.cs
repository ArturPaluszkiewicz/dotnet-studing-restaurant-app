using RestaurantApi.Models;

namespace RestaurantApi.Services
{
    public interface IDishService
    {
        public int CreateDish(int resId, CreateDishDto dto);

        public IEnumerable<DishDto> GetAllDishes(int resId);

        public DishDto GetDish(int resId, int dishId);

        public void DeleteDish(int resId, int dishId);
    }
}