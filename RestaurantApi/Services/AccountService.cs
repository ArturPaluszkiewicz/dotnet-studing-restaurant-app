using RestaurantApi.Entities;
using RestaurantApi.Models;

namespace RestaurantApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly RestaurantDbContext _dbContext;
        public AccountService(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateUser(CreateUserDto dto)
        {
            var user = new User(){
                Email = dto.Email,
                Nationality = dto.Nationality,
                DateOfBirth = dto.DateOfBirth,
                RoleId = dto.RoleId
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }
    }
}