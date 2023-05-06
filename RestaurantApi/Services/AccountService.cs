using Microsoft.AspNetCore.Identity;
using RestaurantApi.Entities;
using RestaurantApi.Models;

namespace RestaurantApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHusher; 
        public AccountService(RestaurantDbContext dbContext, IPasswordHasher<User> passwordHusher)
        {
            _dbContext = dbContext;
            _passwordHusher = passwordHusher;
        }

        public void CreateUser(CreateUserDto dto)
        {
            var newUser = new User(){
                Email = dto.Email,
                Nationality = dto.Nationality,
                DateOfBirth = dto.DateOfBirth,
                RoleId = dto.RoleId
            };

            var hashedPassword = _passwordHusher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }
    }
}