using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData() {
            /* En una nueva Lista de restaurantes se añaden sus objetos */
            restaurants = new List<Restaurant>() {
                new Restaurant { Id = 1, Name= "Scot Pizza", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name= "David Pizza", Cuisine = CuisineType.Mexico},
                new Restaurant { Id = 3, Name= "French Pizza", Cuisine = CuisineType.French}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name); /* OrderBy from LINQ*/
        }

        public Restaurant GetOne(int id)
        {
            return restaurants.FirstOrDefault(response => response.Id == id);
        }
    }
}
