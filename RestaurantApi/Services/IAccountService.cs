using RestaurantApi.Models;

namespace RestaurantApi.Services
{
    public interface IAccountService
    {
        public void CreateUser(CreateUserDto dto);
        public string GenerateJwt(LoginDto login);
    }
}