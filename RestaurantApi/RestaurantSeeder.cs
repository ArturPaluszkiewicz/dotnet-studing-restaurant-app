using RestaurantApi.Entities;

namespace RestaurantApi{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext){
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.AddRange(restaurants);
                    _dbContext.SaveChanges();

                }
            }

        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant.",
                    ContactEmail ="contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chcicken",
                            Price = 10.30M,
                        },
                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 5.30M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Krakow",
                        Street = "Dluga 5",
                        PostalCode = "30-001"
                    }
                },
                new Restaurant()
                {
                    Name = "McDonald",
                    Category = "Fast Food",
                    Description = "McDonald's Corporation (McDonald's), incorporated on December 21, 1964",
                    HasDelivery = true,
                    Address = new Address()
                    {
                        City = "Krakow",
                        Street = "Szewska 2",
                        PostalCode = "30-001"
                    }
                }
            };
            return restaurants;
        }
    }
}