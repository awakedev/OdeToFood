using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurauntData : IRestaurauntData
    {
        private List<Restauraunt> restauraunts;

        public InMemoryRestaurauntData()
        {
            restauraunts = new List<Restauraunt>()
            {
                new Restauraunt { Id = 1, Name = "Corry's Pizza", Location = "Belfast", Cuisine = CuisineType.Italian},
                new Restauraunt { Id = 2, Name = "Ganges", Location = "North India", Cuisine = CuisineType.Indian},
                new Restauraunt { Id = 3, Name = "Tims Taco's", Location = "Mexico City", Cuisine = CuisineType.Mexican},
                new Restauraunt { Id = 4, Name = "Krissys", Location = "Bangor", Cuisine = CuisineType.None},
                new Restauraunt { Id = 5, Name = "Jens", Location = "Blackburn", Cuisine = CuisineType.None}
            };
        }

        public Restauraunt GetById(int id)
        {
            return restauraunts.SingleOrDefault(r => r.Id == id);
        }

        public Restauraunt Add(Restauraunt newRestauraunt)
        {
            restauraunts.Add(newRestauraunt);
            newRestauraunt.Id = restauraunts.Max(r => r.Id) + 1;
            return newRestauraunt;
        }

        public Restauraunt Update(Restauraunt updatedRestauraunt)
        {
            var restauraunt = restauraunts.SingleOrDefault(r => r.Id == updatedRestauraunt.Id);
            if (restauraunt != null)
            {
                restauraunt.Name = updatedRestauraunt.Name;
                restauraunt.Name = updatedRestauraunt.Name;
                restauraunt.Name = updatedRestauraunt.Name;
            }
            return restauraunt;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Restauraunt> GetAll()
        {
            return from r in restauraunts
                   orderby r.Name
                   select r;
        }

        public IEnumerable<Restauraunt> GetRestaurauntsByName(string name)
        {
            return from r in restauraunts
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restauraunt Delete(int id)
        {
            var restauraunt = restauraunts.FirstOrDefault(r => r.Id == id);
            if (restauraunt != null)
            {
                restauraunts.Remove(restauraunt);
            }
            return restauraunt;
        }
    }
}