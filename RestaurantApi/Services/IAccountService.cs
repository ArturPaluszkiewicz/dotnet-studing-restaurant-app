using RestaurantApi.Models;

namespace RestaurantApi.Services
{
    public interface IAccountService
    {
        public int CreateUser(CreateUserDto dto);
    }
}