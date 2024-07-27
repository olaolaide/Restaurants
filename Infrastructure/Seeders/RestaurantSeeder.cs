using Domain.Entities;
using Infrastructure.Persistence;


namespace Infrastructure.Seeders
{
    internal class RestaurantSeeder(RestaurantsDbContext context) : IRestaurantSeeder
    {
        public async Task Seed()
        {
            if (await context.Database.CanConnectAsync())
            {
                if (!context.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    await context.Restaurants.AddRangeAsync(restaurants);
                    await context.SaveChangesAsync();
                }
            }
        }

        private static List<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurants =
            [
                new Restaurant
                {
                    Name = "Joe's Pizza",
                    Description = "Famous for its classic New York style pizza.",
                    Category = "Italian",
                    HasDelivery = true,
                    ContactEmail = "contact@joespizza.com",
                    ContactNumber = "123-456-7890",
                    Address = new Address
                    {
                        City = "New York",
                        Street = "233 Bleecker Street",
                        PostalCode = "10014"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Margherita",
                            Description = "Classic Margherita pizza with fresh mozzarella and basil.", Price = 12.99M,
                            KiloCalories = 250
                        },
                        new Dish
                        {
                            Name = "Pepperoni", Description = "Pepperoni pizza with a spicy kick.", Price = 14.99M,
                            KiloCalories = 300
                        }
                    }
                },

                new Restaurant
                {
                    Name = "Taco Bell",
                    Description = "Fast food restaurant serving Mexican-inspired fare.",
                    Category = "Mexican",
                    HasDelivery = true,
                    ContactEmail = "contact@tacobell.com",
                    ContactNumber = "123-456-7891",
                    Address = new Address
                    {
                        City = "Los Angeles",
                        Street = "123 Taco Street",
                        PostalCode = "90001"
                    },
                    Dishes =
                    [
                        new Dish
                        {
                            Name = "Crunchwrap Supreme", Description = "A crunchy and cheesy delight.", Price = 3.99M,
                            KiloCalories = 540
                        },

                        new Dish
                        {
                            Name = "Quesadilla", Description = "Grilled to perfection with melted cheese.",
                            Price = 4.99M, KiloCalories = 520
                        }
                    ]
                },

                new Restaurant
                {
                    Name = "Sushi Samba",
                    Description = "Japanese-Brazilian fusion cuisine with a vibrant atmosphere.",
                    Category = "Fusion",
                    HasDelivery = false,
                    ContactEmail = "contact@sushisamba.com",
                    ContactNumber = "123-456-7892",
                    Address = new Address
                    {
                        City = "Miami",
                        Street = "600 Lincoln Road",
                        PostalCode = "33139"
                    },
                    Dishes =
                    [
                        new Dish
                        {
                            Name = "Samba Roll", Description = "Signature sushi roll with fresh ingredients.",
                            Price = 15.99M, KiloCalories = 200
                        },

                        new Dish
                        {
                            Name = "Tuna Tataki", Description = "Seared tuna with a tangy sauce.", Price = 13.99M,
                            KiloCalories = 150
                        }
                    ]
                },

                new Restaurant
                {
                    Name = "Le Gourmet",
                    Description = "French fine dining experience with exquisite dishes.",
                    Category = "French",
                    HasDelivery = false,
                    ContactEmail = "contact@legourmet.com",
                    ContactNumber = "123-456-7893",
                    Address = new Address
                    {
                        City = "Paris",
                        Street = "10 Rue de Rivoli",
                        PostalCode = "75001"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Foie Gras", Description = "Delicate foie gras with fig jam.", Price = 25.99M,
                            KiloCalories = 400
                        },
                        new Dish
                        {
                            Name = "Coq au Vin", Description = "Classic chicken dish with red wine sauce.",
                            Price = 22.99M, KiloCalories = 450
                        }
                    }
                },

                new Restaurant
                {
                    Name = "Burger Joint",
                    Description = "Casual spot for gourmet burgers and craft beers.",
                    Category = "American",
                    HasDelivery = true,
                    ContactEmail = "contact@burgerjoint.com",
                    ContactNumber = "123-456-7894",
                    Address = new Address
                    {
                        City = "Chicago",
                        Street = "123 Burger Lane",
                        PostalCode = "60657"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Cheeseburger", Description = "Juicy beef burger with cheddar cheese.",
                            Price = 9.99M, KiloCalories = 700
                        },
                        new Dish
                        {
                            Name = "Veggie Burger", Description = "Delicious vegetarian burger with avocado.",
                            Price = 8.99M, KiloCalories = 600
                        }
                    }
                },

                new Restaurant
                {
                    Name = "Dragon Palace",
                    Description = "Authentic Chinese cuisine with a modern twist.",
                    Category = "Chinese",
                    HasDelivery = true,
                    ContactEmail = "contact@dragonpalace.com",
                    ContactNumber = "123-456-7895",
                    Address = new Address
                    {
                        City = "San Francisco",
                        Street = "555 Dragon Street",
                        PostalCode = "94133"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Kung Pao Chicken", Description = "Spicy chicken with peanuts and vegetables.",
                            Price = 11.99M, KiloCalories = 350
                        },
                        new Dish
                        {
                            Name = "Sweet and Sour Pork", Description = "Pork in a tangy sweet and sour sauce.",
                            Price = 10.99M, KiloCalories = 400
                        }
                    }
                },

                new Restaurant
                {
                    Name = "Cafe Roma",
                    Description = "Charming cafe offering Italian coffee and pastries.",
                    Category = "Cafe",
                    HasDelivery = false,
                    ContactEmail = "contact@caferoma.com",
                    ContactNumber = "123-456-7896",
                    Address = new Address
                    {
                        City = "Rome",
                        Street = "Via Condotti, 12",
                        PostalCode = "00187"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Espresso", Description = "Rich and strong Italian coffee.", Price = 1.99M,
                            KiloCalories = 5
                        },
                        new Dish
                        {
                            Name = "Cannoli", Description = "Sweet Sicilian pastry with ricotta filling.",
                            Price = 2.99M, KiloCalories = 250
                        }
                    }
                },

                new Restaurant
                {
                    Name = "Spice Route",
                    Description = "Indian restaurant serving a variety of flavorful dishes.",
                    Category = "Indian",
                    HasDelivery = true,
                    ContactEmail = "contact@spiceroute.com",
                    ContactNumber = "123-456-7897",
                    Address = new Address
                    {
                        City = "New Delhi",
                        Street = "45 Spice Street",
                        PostalCode = "110001"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Butter Chicken", Description = "Creamy tomato-based chicken curry.", Price = 12.99M,
                            KiloCalories = 500
                        },
                        new Dish
                        {
                            Name = "Paneer Tikka", Description = "Grilled paneer with spices.", Price = 10.99M,
                            KiloCalories = 300
                        }
                    }
                },

                new Restaurant
                {
                    Name = "El Rancho",
                    Description = "Traditional Mexican food with a vibrant atmosphere.",
                    Category = "Mexican",
                    HasDelivery = false,
                    ContactEmail = "contact@elrancho.com",
                    ContactNumber = "123-456-7898",
                    Address = new Address
                    {
                        City = "Mexico City",
                        Street = "100 Fiesta Avenue",
                        PostalCode = "01000"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Tacos Al Pastor", Description = "Marinated pork tacos with pineapple.",
                            Price = 9.99M, KiloCalories = 350
                        },
                        new Dish
                        {
                            Name = "Churros", Description = "Crispy fried dough with cinnamon sugar.", Price = 3.99M,
                            KiloCalories = 450
                        }
                    }
                },

                new Restaurant
                {
                    Name = "Samba Grill",
                    Description = "Brazilian steakhouse with an all-you-can-eat buffet.",
                    Category = "Brazilian",
                    HasDelivery = true,
                    ContactEmail = "contact@sambagrill.com",
                    ContactNumber = "123-456-7899",
                    Address = new Address
                    {
                        City = "Rio de Janeiro",
                        Street = "500 Beach Boulevard",
                        PostalCode = "22010"
                    },
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Picanha", Description = "Grilled top sirloin steak.", Price = 19.99M,
                            KiloCalories = 700
                        },
                        new Dish
                        {
                            Name = "Feijoada", Description = "Traditional black bean stew with pork.", Price = 14.99M,
                            KiloCalories = 600
                        }
                    }
                }
            ];

            return restaurants;
        }
    }
}
