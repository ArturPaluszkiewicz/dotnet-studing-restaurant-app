using RestaurantApi.Models;

namespace RestaurantApi.Services
{
    public interface IDishService
    {
        public int CreateDish(int resId, CreateDishDto dto);

        public IEnumerable<DishDto> GetAllDishes(int resId);

        public DishDto GetDishById(int resId, int dishId);

        public void DeleteDishById(int resId, int dishId);
        public void DeleteAllDishes(int resId);
    }
}